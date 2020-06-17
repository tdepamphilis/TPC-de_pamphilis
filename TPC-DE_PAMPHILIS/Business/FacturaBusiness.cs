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
                command.CommandText = "insert into facturas values(@code, @userCode, @date, @status, @payment, @value)";
                command.Parameters.AddWithValue("@code", factura.codigo);
                command.Parameters.AddWithValue("@userCode", factura.codigoUsuario);
                command.Parameters.AddWithValue("@status", factura.estado);
                command.Parameters.AddWithValue("@payment", factura.modoDePago);
                command.Parameters.AddWithValue("@value", (decimal)factura.monto);
                command.Parameters.AddWithValue("date", factura.fecha);
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

    }
}
