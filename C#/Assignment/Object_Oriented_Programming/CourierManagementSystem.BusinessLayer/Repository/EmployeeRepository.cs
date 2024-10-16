using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entitiy;

namespace CourierManagementSystem.BusinessLayer.Repository
{
    public class EmployeeRepository:IEmployeeRepository

    {
        // Default constructor
        public EmployeeRepository() { }

        //Parameterized constructor
        Employee employee = new Employee();
        public EmployeeRepository(int employeeID, string employeeName, string email, string contactNumber, string role, double salary)
        {
            employee.employeeID = employeeID;
            employee.employeeName = employeeName;
            employee.email = email;
            employee.contactNumber = contactNumber;
            employee.role = role;
            employee.salary = salary;
        }
        public override string ToString()
        {
            return $"Employee {{ employeeID={employee.employeeID}, employeeName='{employee.employeeName}', email='{employee.email}', " +
                   $"contactNumber='{employee.contactNumber}', role='{employee.role}', salary={employee.salary} }}";

        }
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"{employee.employeeID}, {employee.employeeName},{employee.contactNumber},{employee.salary},{employee.role},{employee.email}");
        }
    }
}
