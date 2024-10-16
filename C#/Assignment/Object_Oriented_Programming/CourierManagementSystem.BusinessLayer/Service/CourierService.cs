using CourierManagementSystem.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Service
{


    public class CourierService : ICourierService
    {
        ICourierRepository _courierRepository; 
        public CourierService(CourierRepository courierRepository) 
        {
            _courierRepository = courierRepository;
        }

        public void DisplayCourierInfo()
        {
            throw new NotImplementedException();
        }
    }

}