using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entitiy
{
    public class CourierCompany

    {
        public string CompanyName { get; set; }
        public List<Courier> CourierDetails { get; set; } = new List<Courier>();
        public List<Employee> EmployeeDetails { get; set; } = new List<Employee>();
        public List<Location> LocationDetails { get; set; } = new List<Location>();

    }
}
