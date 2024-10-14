using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagemenySystem_DatabaseConnection
{
    public class CourierServiceDB
    {
        public void GetEmployeeDetails()
        {
            // Use 'using' statement for automatic disposal of the connection and command.
            try
            {
                using (var conn = DBUtil.getDBConnection())
                {
                    conn.Open();

                    // Define the query to fetch employee details (assuming the table is Employee).
                    string query = "SELECT EmployeeID, Name, Email, ContactNumber, Role, Salary FROM Employee";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Employee ID\tName\t\tEmail\t\t\tContact Number\t\tRole\t\tSalary");

                            // Reading and displaying the employee details from the query.
                            while (reader.Read())
                            {
                                Console.WriteLine(
                                    $"{reader["EmployeeID"]}\t\t{reader["Name"]}\t\t{reader["Email"]}\t\t" +
                                    $"{reader["ContactNumber"]}\t\t{reader["Role"]}\t\t{reader["Salary"]}");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle database exceptions, such as connection errors or query issues.
                Console.WriteLine("An error occurred while fetching employee details: " + ex.Message);
            }
        }

        //public void InsertEmployee(Employee employee)
        //{
        //    try
        //    {
        //        var conn = DBUtil.getDBConnection();
        //        conn.Open();

        //        // SQL query to insert a new employee
        //        string query = "INSERT INTO Employee (Name, Email, ContactNumber, Role, Salary) " +
        //                       "VALUES (@Name, @Email, @ContactNumber, @Role, @Salary)";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Name", employee.employeeName);
        //            cmd.Parameters.AddWithValue("@Email", employee.email);
        //            cmd.Parameters.AddWithValue("@ContactNumber", employee.contactNumber);
        //            cmd.Parameters.AddWithValue("@Role", employee.role);
        //            cmd.Parameters.AddWithValue("@Salary", employee.salary);

        //            int result = cmd.ExecuteNonQuery();

        //            if (result == 1)
        //            {
        //                Console.WriteLine("New employee inserted successfully.");
        //            }
        //        }

        //        conn.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error while inserting employee: " + ex.Message);
        //    }
        //}

        // Update existing Employee details (like update Salary or Role)
        //public void UpdateEmployee(Employee employee)
        //{
        //    try
        //    {
        //        var conn = DBUtil.getDBConnection();
        //        conn.Open();

        //        // SQL query to update employee details (update Email, ContactNumber, Role, or Salary)
        //        string query = "UPDATE Employee SET email = @Email, contactNumber = @ContactNumber, " +
        //                       "role = @Role, salary = @Salary WHERE employeeID = @EmployeeID";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Email", employee.email);
        //            cmd.Parameters.AddWithValue("@ContactNumber", employee.contactNumber);
        //            cmd.Parameters.AddWithValue("@Role", employee.role);
        //            cmd.Parameters.AddWithValue("@Salary", employee.salary);
        //            cmd.Parameters.AddWithValue("@EmployeeID", employee.employeeID);

        //            int result = cmd.ExecuteNonQuery();

        //            if (result == 1)
        //            {
        //                Console.WriteLine("Employee details updated successfully.");
        //            }
        //        }

        //        conn.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error while updating employee: " + ex.Message);
        //    }
        //}

        // Delete an Employee by ID
        //public void DeleteEmployee(int employeeID)
        //{
        //    try
        //    {
        //        var conn = DBUtil.getDBConnection();
        //        conn.Open();

        //        // SQL query to delete an employee by EmployeeID
        //        string query = "DELETE FROM Employee WHERE employeeID = @EmployeeID";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

        //            int result = cmd.ExecuteNonQuery();

        //            if (result == 1)
        //            {
        //                Console.WriteLine("Employee removed successfully.");
        //            }
        //        }

        //        conn.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error while deleting employee: " + ex.Message);
        //    }
        //}

        // Retrieve the Employee with the highest salary
        public void GetEmployeeWithMaxSalary()
        {
            try
            {
                var conn = DBUtil.getDBConnection();
                conn.Open();

                // SQL query to get the employee with the maximum salary
                string query = "SELECT TOP 1 employeeID, name, salary FROM Employee ORDER BY salary DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"\nEmployee with highest salary: {reader["Name"]} (ID: {reader["EmployeeID"]}) - Salary: {reader["Salary"]}");
                        }
                    }
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error while retrieving employee with max salary: " + ex.Message);
            }
        }
    }
}
