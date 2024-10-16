using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Service
{
    public interface ICourierAdminService
    {
        int AddCourierStaff(Employee obj);
    }
}
