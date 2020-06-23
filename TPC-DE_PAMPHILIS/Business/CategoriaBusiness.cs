using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Business
{
    public class CategoriaBusiness
    {


        //--------------LECTURA------------------
        public List<Categoria> listar()
        {
            GestorConexion gestor = new GestorConexion();
            List<Categoria> aux = new List<Categoria>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_categorias";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Categoria x = new Categoria();
                    x.id = lector.GetInt32(0);
                    x.name = lector.GetString(1);
                    x.productAmmount = lector.GetInt32(2);
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

        public List<Categoria> buscar(string name)
        {
            GestorConexion gestor = new GestorConexion();
            List<Categoria> aux = new List<Categoria>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_categorias where Nombre like '%" + name + "'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Categoria x = new Categoria();
                    x.id = lector.GetInt32(0);
                    x.name = lector.GetString(1);
                    x.productAmmount = lector.GetInt32(2);
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

        public Categoria buscarid(int id)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_categorias where Id = '" + id+"'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                Categoria x = new Categoria();

                while (lector.Read())
                {
                    x.id = lector.GetInt32(0);
                    x.name = lector.GetString(1);
                    x.productAmmount = lector.GetInt32(2);

                }
                connection.Close();
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Categoria getFromName(string name)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_categorias where Nombre = @name";
                command.Parameters.AddWithValue("@name", name);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                Categoria x = new Categoria();
                while (lector.Read())
                {
                    x.id = lector.GetInt32(0);
                    x.name = lector.GetString(1);
                    x.productAmmount = lector.GetInt32(2);

                }
                connection.Close();
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool checkItemInCategory(int catid, string prodid)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            bool result = true;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select count(*) from categoriaxarticulo where CodigoArticulo = @prod and Idcategoria = @cat";
                command.Parameters.AddWithValue("@prod", prodid);
                command.Parameters.AddWithValue("@cat", catid);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                Categoria x = new Categoria();
                lector.Read();
                if (lector.GetInt32(0) == 0)
                    result = false;

                
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }


        }
        //------------ESCRITURA------------------

        public void rename(int id, string newname)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {
                
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE CATEGORIAS set Nombre = @name where Id = @code";
                command.Parameters.AddWithValue("@name", newname);
                command.Parameters.AddWithValue("@code", id);
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

        public void cleanProducts(int id)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from categoriaxarticulo  where Idcategoria = @code";
                command.Parameters.AddWithValue("@code", id);
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

        public void assignCategories(int catid,string prodid)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into categoriaxarticulo values (@art, @cat)";
                command.Parameters.AddWithValue("@art", prodid);
                command.Parameters.AddWithValue("@cat", catid);
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

        public void delete(int id)
        {
            cleanProducts(id);
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from categorias  where Id = @code";
                command.Parameters.AddWithValue("@code", id);
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

        public void create(string name)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT into CATEGORIAS values (@name)";
                command.Parameters.AddWithValue("@name", name);
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
    }
}
