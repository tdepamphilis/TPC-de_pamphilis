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
                command.CommandText = "select * from vw_articulos where Nombre like '%" + busqueda + "%'";
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
    }
}
