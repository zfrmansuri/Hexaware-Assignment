using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entitiy
{
    public class CourierCompanyCollection
    {
        // store all courier companies dynamically
        private List<CourierCompany> courierCompanies;
        public CourierCompanyCollection()
        {
            courierCompanies = new List<CourierCompany>(); 
        }

        // include courier company
        public void AddCourierCompany(CourierCompany company)
        {
            courierCompanies.Add(company);
        }


        //courier companies
        public CourierCompany GetCourierCompany(string companyName)
        {
            return courierCompanies.Find(c => c.CompanyName == companyName);
        }

        // find every courier companies
        public List<CourierCompany> GetAllCourierCompanies()
        {
            return courierCompanies;
        }
    }
}
