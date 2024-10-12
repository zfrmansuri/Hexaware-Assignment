using System;
using System.Data.SqlClient;
using CourierManagementSystem.entity;
using CourierManagementSystem.util;

namespace CourierManagementSystem.dao
{
    public class CourierServiceDb
    {
        // Static variable to hold the database connection
        private static SqlConnection connection;

        // Constructor to initialize the database connection
        public CourierServiceDb()
        {
            connection = DBConnUtil.GetConnection();  // Get the connection from DBConnUtil class
        }

        // Method to insert a new courier order into the database
        public void InsertCourier(Courier courier)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                // SQL Query to insert a new courier order
                string query = @"INSERT INTO Courier 
                                    (SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate) 
                                 VALUES 
                                    (@SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status, @TrackingNumber, @DeliveryDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SenderName", courier.SenderName);
                command.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
                command.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
                command.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
                command.Parameters.AddWithValue("@Weight", courier.Weight);
                command.Parameters.AddWithValue("@Status", courier.Status);
                command.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
                command.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Courier order inserted successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to insert courier order.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Method to update the courier status based on tracking number
        public void UpdateCourierStatus(string trackingNumber, string newStatus)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                // SQL Query to update the status of a courier order
                string query = @"UPDATE Courier 
                                 SET Status = @NewStatus 
                                 WHERE TrackingNumber = @TrackingNumber";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewStatus", newStatus);
                command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Courier status updated successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to update courier status.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Method to retrieve courier details by tracking number
        public Courier GetCourierByTrackingNumber(string trackingNumber)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                // SQL Query to retrieve courier details by tracking number
                string query = "SELECT * FROM Courier WHERE TrackingNumber = @TrackingNumber";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                SqlDataReader reader = command.ExecuteReader();

                // Check if data was found
                if (reader.Read())
                {
                    // Create and populate the Courier object
                    Courier courier = new Courier
                    {
                        CourierID = Convert.ToInt32(reader["CourierID"]),
                        SenderName = reader["SenderName"].ToString(),
                        SenderAddress = reader["SenderAddress"].ToString(),
                        ReceiverName = reader["ReceiverName"].ToString(),
                        ReceiverAddress = reader["ReceiverAddress"].ToString(),
                        Weight = Convert.ToDouble(reader["Weight"]),
                        Status = reader["Status"].ToString(),
                        TrackingNumber = reader["TrackingNumber"].ToString(),
                        DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"])
                    };

                    reader.Close();
                    return courier;
                }
                else
                {
                    Console.WriteLine("Courier not found.");
                    reader.Close();
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
