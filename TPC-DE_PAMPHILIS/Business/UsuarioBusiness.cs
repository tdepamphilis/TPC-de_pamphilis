using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

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

        //-------------CODIGOS------------------

        private bool checkCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            SqlDataReader  lector;
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
    }
}
