using System;
using System.Data.SqlClient;

namespace CourierManagementSystem.util
{
    public class DBConnUtil
    {
        //database connection details 
        private static string connectionString = "Data Source = ZFR-DESKTOP; Initial Catalog=CourierDB; Integrated Security=true";

        // Method to establish and return a connection to the SQL database
        public static SqlConnection GetConnection()
        {
            try
            {
                // Create a new SqlConnection object using the connection string
                SqlConnection connection = new SqlConnection(connectionString);

                // Open the connection
                connection.Open();
                Console.WriteLine("Database connection established successfully!");

                return connection;  // Return the open connection
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error while connecting to the database: " + ex.Message);
                return null;
            }
        }
    }
}
