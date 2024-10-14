using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entitiy
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
        public string role { get; set; }
        public double salary { get; set; }
    }
}
