using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
namespace Business
{
    public class MarcaBusiness
    {

        //--------------LECTURA------------------
        public List<Marca> listar()
        {
            GestorConexion gestor = new GestorConexion();
            List<Marca> aux = new List<Marca>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_marcas";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Marca x = new Marca();
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

        public List<Marca> buscar(string name)
        {
            GestorConexion gestor = new GestorConexion();
            List<Marca> aux = new List<Marca>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_marcas where Nombre like '%"+name+"%'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Marca x = new Marca();
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

    }
}
