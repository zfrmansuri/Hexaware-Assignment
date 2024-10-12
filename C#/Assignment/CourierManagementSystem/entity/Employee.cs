using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.entity
{
    public class Employee
    {
        private int employeeID;
        private string employeeName;
        private string email;
        private string contactNumber;
        private string role;
        private double salary;

        // Default Constructor
        public Employee() { }

        // Parameterized Constructor
        public Employee(int employeeID, string employeeName, string email, string contactNumber, string role, double salary)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.email = email;
            this.contactNumber = contactNumber;
            this.role = role;
            this.salary = salary;
        }

        // Getters and Setters
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string Email { get => email; set => email = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Role { get => role; set => role = value; }
        public double Salary { get => salary; set => salary = value; }

        // ToString Method
        public override string ToString()
        {
            return $"EmployeeID: {employeeID}, EmployeeName: {employeeName}, Email: {email}, ContactNumber: {contactNumber}, Role: {role}, Salary: {salary}";
        }
    }
}
