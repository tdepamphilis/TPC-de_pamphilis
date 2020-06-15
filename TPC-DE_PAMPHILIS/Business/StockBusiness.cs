using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace Business
{
    public class StockBusiness
    {
        public void updatestock(string productCode, int ammount, decimal price)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE stock set Cantidad = @cant,  PrecioDistribuidor  = @price where CodigoArticulo = @code";
                command.Parameters.AddWithValue("@cant", ammount);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@code", productCode);
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

        public void createData(string productcode)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into stock values (@code, 0, 0)";
                command.Parameters.AddWithValue("@code", productcode);
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

        public void deleteData(string productcode)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from  stock where CodigoArticulo = @code";
                command.Parameters.AddWithValue("@code", productcode);
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
