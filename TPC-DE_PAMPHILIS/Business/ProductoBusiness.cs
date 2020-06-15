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
                    Stock s = new Stock();
                    x.code = lector.GetString(0);
                    x.name = lector.GetString(1);
                    x.desc = lector.GetString(2);
                    x.margin = lector.GetInt32(3);
                    x.urlimagen = lector.GetString(4);
                    y.id = lector.GetInt32(5);
                    y.name = lector.GetString(6);
                    x.marca = y;
                    s.ammount = lector.GetInt32(7);
                    s.price = lector.GetDecimal(8);
                    x.stock = s;


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
                    Stock s = new Stock();
                    x.code = lector.GetString(0);
                    x.name = lector.GetString(1);
                    x.desc = lector.GetString(2);
                    x.margin = lector.GetInt32(3);
                    x.urlimagen = lector.GetString(4);
                    y.id = lector.GetInt32(5);
                    y.name = lector.GetString(6);
                    x.marca = y;
                    s.ammount = lector.GetInt32(9);
                    s.price = lector.GetDecimal(10);
                    x.stock = s;


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

        public Producto buscarid(string code)
        {
            GestorConexion gestor = new GestorConexion();
            Producto aux = new Producto();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_articulos where Codigo = '"+ code+"'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    
                    Marca y = new Marca();
                    Stock s = new Stock();
                    aux.code = lector.GetString(0);
                    aux.name = lector.GetString(1);
                    aux.desc = lector.GetString(2);
                    aux.margin = lector.GetInt32(3);
                    aux.urlimagen = lector.GetString(4);
                    y.id = lector.GetInt32(5);
                    y.name = lector.GetString(6);
                    aux.marca = y;
                    s.ammount = lector.GetInt32(7);
                    s.price = lector.GetDecimal(8);
                    aux.stock = s;

                    
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

        public void clearcategories(string productId)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from categoriaxarticulo  where CodigoArticulo = @code";
                command.Parameters.AddWithValue("@code",productId);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
            }
        }

        public void delete(string code)
        {

            
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from articulos where Codigo = @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
            }
        }

        public void mod(Producto producto)
        {
            try
            {
                delete(producto.code);
                create(producto);
            }
            catch (Exception)
            {

                throw;
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
