using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Repository
{
    public class CourierCompanyRepository : ICourierCompanyRepository
    {
        public CourierCompanyRepository() { }

        //Parameterized constructor
        CourierCompany couriercompany = new CourierCompany();

        public CourierCompanyRepository(string companyName, List<Courier> courierDetails, List<Employee> employeeDetails, List<Location> locationDetails)
        {
            couriercompany.CompanyName = companyName;
            couriercompany.CourierDetails = courierDetails;
            couriercompany.EmployeeDetails = employeeDetails;
            couriercompany.LocationDetails = locationDetails;

        }

        public override string ToString()
        {
            return $"CourierCompany {{ companyName={couriercompany.CompanyName}, courierDetails='{couriercompany.CourierDetails}', employeeDetails='{couriercompany.EmployeeDetails}', " +
                   $"locationDetails='{couriercompany.LocationDetails}' }}";

        }



        public void DisplayCourierCompanyInfo()
        {
            Console.WriteLine($"{couriercompany.CompanyName}, {couriercompany.CourierDetails},{couriercompany.EmployeeDetails},{couriercompany.LocationDetails}");
        }
    }
}

