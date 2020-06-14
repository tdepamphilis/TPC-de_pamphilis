using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
namespace Business
{
    public class ProductoBusiness
    {
        //-------------LECTURA--------------------
        public List<Producto> listar(string busqueda)
        {
            GestorConexion gestor = new GestorConexion();
            List<Producto> aux = new List<Producto>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_articulos where Nombre like '%" + busqueda + "%' or Marca like '%" + busqueda + "%'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Producto x = new Producto();
                    Marca y = new Marca();
                    x.code = lector.GetString(0);
                    x.name = lector.GetString(1);
                    x.desc = lector.GetString(2);
                    x.margin = lector.GetInt32(3);
                    x.urlimagen = lector.GetString(4);
                    y.id = lector.GetInt32(5);
                    y.name = lector.GetString(6);
                    x.marca = y;

                    aux.Add(x);
                }


                connection.Close();
                return aux;



            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Producto> listarxcat(string busqueda, int cat)
        {
            GestorConexion gestor = new GestorConexion();
            List<Producto> aux = new List<Producto>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_articulosxcategoria where (Nombre like '%" + busqueda + "%' or Marca like '%" + busqueda + "%') and IdCategoria = " + cat;
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Producto x = new Producto();
                    Marca y = new Marca();
                    x.code = lector.GetString(0);
                    x.name = lector.GetString(1);
                    x.desc = lector.GetString(2);
                    x.margin = lector.GetInt32(3);
                    x.urlimagen = lector.GetString(4);
                    y.id = lector.GetInt32(5);
                    y.name = lector.GetString(6);
                    x.marca = y;

                    aux.Add(x);
                }


                connection.Close();
                return aux;



            }
            catch (Exception)
            {

                throw;
            }


        }


        //------------ESCRITURA-------------------

        public void deleteBrandProducts(int idMarca)
        {
           
                GestorConexion gestor = new GestorConexion();
                SqlConnection connection = gestor.connection();
                SqlCommand command = new SqlCommand();
                try
                {

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "delete from articulos where IdMarca = @code";
                    command.Parameters.AddWithValue("@code", idMarca);
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

        public void create(Producto producto)
        {

            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {
               
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into ARTICULOS values(@cod, @nombre, @desc, @marca, @imagen, @margen)";
                command.Parameters.AddWithValue("@cod", producto.code);
                command.Parameters.AddWithValue("@nombre", producto.name);
                command.Parameters.AddWithValue("@desc", producto.desc);
                command.Parameters.AddWithValue("@marca", producto.marca.id);
                
                command.Parameters.AddWithValue("@imagen", producto.urlimagen);
                command.Parameters.AddWithValue("@margen", producto.margin);
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

        //------------GENERACION DE CODIGO-----------------
        public bool checkcode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            bool found = false;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_articulos where Codigo ='" + code + "'";
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
                var stringChars = new Char[5];
                Random random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                string result = new string(stringChars);

                if (!checkcode(result))
                {
                    return result;

                }
            }


        }
    }
}
