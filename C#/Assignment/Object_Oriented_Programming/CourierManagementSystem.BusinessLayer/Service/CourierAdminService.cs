using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Service
{
    public class CourierAdminService : ICourierAdminService
    {
        private List<Employee> employees = new List<Employee>(); e
        private static int employeeCounter = 100; 

        // Add courier staff member and return ID
        public int AddCourierStaff(Employee obj)
        {
            obj.employeeID = ++employeeCounter;
            employees.Add(obj);
            return obj.employeeID;
        }
    }
}
