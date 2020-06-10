using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Business
{
    public class GestorConexion
    {
        public SqlConnection connection()
        {
            SqlConnection aux = new SqlConnection();
        
            aux.ConnectionString = "data source = DESKTOP-9SD09P6\\SQLEXPRESS; initial catalog = depamphilis_db; integrated security = sspi";
            return aux;
        }
    }
}

