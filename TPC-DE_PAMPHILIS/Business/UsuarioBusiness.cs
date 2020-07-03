using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.Policy;

namespace Business
{
    public class UsuarioBusiness
    {
        //--------------LECTURA--------------
        public int checkMail(string mail)
        {
            int x = 0;
            GestorConexion gestor = new GestorConexion();

            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Count(*) from usuarios where Correo = '" + mail + "'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();

                while (lector.Read())
                {
                    x = lector.GetInt32(0);
                }


                connection.Close();
                return x;



            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CheckAlta(string mail, string pass)
        {
            int x = 0;
            GestorConexion gestor = new GestorConexion();

            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Count(*) from usuarios where Correo = @correo and Password = @pass";
                command.Parameters.AddWithValue("@correo", mail);
                command.Parameters.AddWithValue("@pass", pass);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();

                while (lector.Read())
                {
                    x = lector.GetInt32(0);
                }


                connection.Close();
                return x;



            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario login(string mail, string pass)
        {
            Usuario usuario = new Usuario();
            Zona zona = new Zona();
            GestorConexion gestor = new GestorConexion();

            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_usuarios where Correo = @correo and Password = @pass";
                command.Parameters.AddWithValue("@correo", mail);
                command.Parameters.AddWithValue("@pass", pass);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();
                usuario.code = lector.GetString(0);
                usuario.name = lector.GetString(1);
                usuario.apellido = lector.GetString(2);
                usuario.dni = lector.GetInt32(3);
                usuario.mail = lector.GetString(4);
                usuario.pass = lector.GetString(5);
                usuario.direccion = lector.GetString(6);
                zona.id = lector.GetInt32(7);
                zona.name = lector.GetString(8);
                usuario.zona = zona;
                connection.Close();
                List<string> favs = favoritos(usuario.code);
                usuario.favoritos = favs;

                

                return usuario;



            }
            catch (Exception)
            {

                throw;
            }
        }



        public List<string> favoritos(string usercode)
        {
            List<string> aux = new List<string>();
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_favoritos where Usuario = @user ";
                command.Parameters.AddWithValue("@user", usercode);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();

                while (lector.Read())
                {
                    string x = lector.GetString(1);
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
        //-------------CODIGOS------------------

        private bool checkCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Count(*) from usuarios where Codigo = @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();
                int x = lector.GetInt32(0);

                if (x != 0)
                    result = true;

                connection.Close();
                return result;

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

                if (!checkCode(result))
                {
                    return result;

                }
            }
        }

        //---------ESCRITURA-------------

        public void nuevoUsuario(Usuario usuario)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "exec SP_AltaUsuario @Codigo, @Nombre, @Apellido, @DNI, @Correo, @Password, @Dir, @Zona ";
                command.Parameters.AddWithValue("@Codigo", usuario.code);
                command.Parameters.AddWithValue("@Nombre", usuario.name);
                command.Parameters.AddWithValue("@Apellido", usuario.apellido);
                command.Parameters.AddWithValue("@DNI", usuario.dni);
                command.Parameters.AddWithValue("@Correo", usuario.mail);
                command.Parameters.AddWithValue("@Password", usuario.pass);
                command.Parameters.AddWithValue("@Dir", usuario.direccion);
                command.Parameters.AddWithValue("@Zona", usuario.zona.id);
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

        public void removeFav(string prodcode, string usercode)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from favoritosxusuario where Usuario = @user and Articulo = @art";
                command.Parameters.AddWithValue("@user", usercode);
                command.Parameters.AddWithValue("@art", prodcode);
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

        public void addFav(string prodcode, string usercode)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into favoritosxusuario values (@user, @art)";
                command.Parameters.AddWithValue("@user", usercode);
                command.Parameters.AddWithValue("@art", prodcode);
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

        public void cambiarPass(string mail, string pass, string newpass)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update usuarios set Password = @newpass where Correo = @mail and Password = @oldpass";
                command.Parameters.AddWithValue("@mail", mail );
                command.Parameters.AddWithValue("@oldpass", pass);
                command.Parameters.AddWithValue("@newpass", newpass);
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
