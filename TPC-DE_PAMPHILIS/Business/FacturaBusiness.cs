using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Business
{
    public class FacturaBusiness
    {

        public void GenerarCompra(Factura factura)
        {
            bool done = false;
            while (!done)
            {
                factura.codigo = generateCode();
                SaveFactura(factura);
                if (checkFactura(factura))
                    done = true;
            }
            // saveitems




        }



        //-------ESCRITURA---------------


        public void saveItems(ItemCarrito item, string codigoFactura)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;


                command.CommandText += "insert into itemsxfactura values(@ArtCode, @CodigoFactura, @price, @cant) ";
                command.Parameters.AddWithValue("@ArtCode", item.code);
                command.Parameters.AddWithValue("@CodigoFactura", codigoFactura);
                command.Parameters.AddWithValue("@price", (decimal)item.unitPrice);
                command.Parameters.AddWithValue("@cant", item.ammount);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }



        public void SaveFactura(Factura factura)
        {
            if (factura.codigo == null)
                factura.codigo = generateCode();

            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "exec SP_CargaFactura @code, @userCode, @date , @status, @payment, @value, @dir";
                command.Parameters.AddWithValue("@code", factura.codigo);
                command.Parameters.AddWithValue("@userCode", factura.codigoUsuario);
                command.Parameters.AddWithValue("@status", factura.estado);
                command.Parameters.AddWithValue("@payment", factura.modoDePago);
                command.Parameters.AddWithValue("@value", (decimal)factura.monto);
                command.Parameters.AddWithValue("@date", factura.fecha);
                command.Parameters.AddWithValue("@dir", factura.dir);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                foreach (ItemCarrito item in factura.items)
                {

                    saveItems(item, factura.codigo);
                }


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }




        }



        //--------GENERACION DE CODIGO--------------

        private bool checkCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            bool found = false;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from facturas where Codigo ='" + code + "'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    found = true;
                }
                connection.Close();
                return found;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string generateCode()
        {
            while (true)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new Char[15];
                Random random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                string result = new string(stringChars);

                if (!checkCode(result))
                {
                    return result;

                }
            }
        }

        // ---------------VALIDACION--------------------

        private bool checkFactura(Factura factura)
        {
            
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
           
            int x;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Count(*) from facturas where Codigo = @code and CodigoUsuario = @user";
                command.Parameters.AddWithValue("@code", factura.codigo);
                command.Parameters.AddWithValue("@user", factura.codigoUsuario);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();
                x = lector.GetInt32(0);
                connection.Close();
                if (x != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
