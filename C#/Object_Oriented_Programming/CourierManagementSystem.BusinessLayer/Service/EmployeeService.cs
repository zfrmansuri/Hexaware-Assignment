using CourierManagementSystem.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Service
{
    

        public class EmployeeService : IEmployeeService
        {
            IEmployeeRepository _employeeRepository; 
            public EmployeeService(EmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            public void DisplayEmployeeInfo()
            {
                _employeeRepository.DisplayEmployeeInfo();
            }
        }
    }
