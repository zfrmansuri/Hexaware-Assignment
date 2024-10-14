using CourierManagementSystem.BusinessLayer.Repository;
using CourierManagementSystem.BusinessLayer.Service;
using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagemenySystem_DatabaseConnection;




namespace CourierManagementSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository er = new EmployeeRepository(101, "Zafar", "zafar@gmail.com", "9131487025", "Admin", 90000);
            EmployeeService es = new EmployeeService(er);


            es.DisplayEmployeeInfo();
            es.ToString();

            CourierRepository cr = new CourierRepository();

            ICourierUserService courierUserService = new CourierUserService();
            ICourierAdminService courierAdminService = new CourierAdminService();

            // Admin adds a new courier staff member
            Employee newEmployee = new Employee { employeeName = "Pratham", email = "Pratham@gmail.com", contactNumber = "4342532124", role = "Courier", salary = 70000 };
            int employeeId = courierAdminService.AddCourierStaff(newEmployee);
            Console.WriteLine($"Courier staff Added with ID: {employeeId}");


            // User placeing order
            Courier courier = new Courier
            {
                courierID = 101,

                senderName = "Zafar",
                senderAddress = "Freeganj Ujjain",
                receiverName = "Shakil",
                receiverAddress = "Dewas",
                weight = 7.2,
                status = "InTransit",
                TrackingNumber = "TRK1234",
                deliveryDate = DateTime.Now.AddDays(4),
                employeeID = employeeId
            };
            //courier.CourierID = employeeId;
            string trackingNumber = courierUserService.PlaceOrder(courier);
            Console.WriteLine($"Order placed. Tracking number: {trackingNumber}");

            // Check order status
            string status = courierUserService.GetOrderStatus(trackingNumber);
            Console.WriteLine($"Order status: {status}");

            // Cancel order
            bool cancelResult = courierUserService.CancelOrder(trackingNumber);
            Console.WriteLine($"Order canceled: {cancelResult}");

            // Tqsk - 9 Database Connection 
            CourierServiceDB courierServiceDb = new CourierServiceDB();

            // 1. Retrieve all employees
            courierServiceDb.GetEmployeeDetails();

            // 2. Insert a new employee
            //Employee newE = new Employee
            //{
            //    employeeName = "Raj Patel",
            //    email = "raj@gmail.com",
            //    contactNumber = "4297492479",
            //    role = "employee",
            //    salary = 30000.00D
            //};
            //courierServiceDb.InsertEmployee(newE);

            // 3. Update an employee's details
            //Employee updateEmployee = new Employee
            //{
            //    employeeID = 1, 
            //    email = "Chnage.email@example.com",
            //    contactNumber = "4298734972",
            //    role = "Manager",
            //    salary = 1500000.00D
            //};
            //courierServiceDb.UpdateEmployee(updateEmployee);

            // 4. Delete an employee
            //courierServiceDb.DeleteEmployee(4);  //employee with id=4 will be deleted

            // 5. Find the employee with the highest salary
            courierServiceDb.GetEmployeeWithMaxSalary();
            Console.ReadKey();
        }
    }
}
