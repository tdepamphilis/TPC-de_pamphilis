using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Business
{
    public class AdminBusiness
    {
    //----------LECTURA----------------
        
        public int checkAdmin(string mail, string pass)
        {
            int x = 0;
           
            GestorConexion gestor = new GestorConexion();

            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Count(*) from admins where Correo = @mail and Password = @pass";
                command.Parameters.AddWithValue("@mail", mail);
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

        public Admin login(string mail, string pass)
        {
            Admin admin = new Admin();
            GestorConexion gestor = new GestorConexion();

            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from admins where Correo = @mail and Password = @pass";
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@pass", pass);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();

                admin.code = lector.GetString(0);
                admin.mail = lector.GetString(1);
                admin.pass = lector.GetString(2);
                admin.name = lector.GetString(3);

                


                connection.Close();
                return admin;



            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
