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
                command.CommandText = "select * from categorias";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Categoria x = new Categoria();
                    x.id = lector.GetInt32(0);
                    x.name = lector.GetString(1);
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
