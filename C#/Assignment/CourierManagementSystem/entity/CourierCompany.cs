using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.entity
{
    internal class CourierCompany
    {
        private string companyName;
        private List<Courier> courierDetails; // Collection of Courier Objects
        private List<Employee> employeeDetails; // Collection of Employee Objects
        private List<Location> locationDetails; // Collection of Location Objects

        // Default Constructor
        public CourierCompany()
        {
            courierDetails = new List<Courier>();
            employeeDetails = new List<Employee>();
            locationDetails = new List<Location>();
        }

        // Parameterized Constructor
        public CourierCompany(string companyName, List<Courier> courierDetails, List<Employee> employeeDetails, List<Location> locationDetails)
        {
            this.companyName = companyName;
            this.courierDetails = courierDetails;
            this.employeeDetails = employeeDetails;
            this.locationDetails = locationDetails;
        }

        // Getters and Setters
        public string CompanyName { get => companyName; set => companyName = value; }
        public List<Courier> CourierDetails { get => courierDetails; set => courierDetails = value; }
        public List<Employee> EmployeeDetails { get => employeeDetails; set => employeeDetails = value; }
        public List<Location> LocationDetails { get => locationDetails; set => locationDetails = value; }

        // ToString Method
        public override string ToString()
        {
            return $"CompanyName: {companyName}, Total Couriers: {courierDetails.Count}, Total Employees: {employeeDetails.Count}, Total Locations: {locationDetails.Count}";
        }
    }
}
