using CourierManagementSystem.entity;
using CourierManagementSystem.exception;
using System;
using System.Collections.Generic;

namespace CourierManagementSystem.dao
{
    public class CourierAdminService : ICourierAdminService
    {
        // A list to store employees
        private List<Employee> employees = new List<Employee>();

        // Add a new courier staff member to the system
        public int AddCourierStaff(Employee obj)
        {
            employees.Add(obj);
            return obj.EmployeeID; // Return the ID of the added staff member
        }

    }
}
