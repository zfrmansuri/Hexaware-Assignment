using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagemenySystem_DatabaseConnection
{
    public class DBUtil
    {
        public static SqlConnection getDBConnection()
        {
            SqlConnection conn;
            string connectionstring = "Data Source = ZFR-DESKTOP; Initial Catalog=CourierDB; Integrated Security=true";
            conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            return conn;
        }
    }
}
