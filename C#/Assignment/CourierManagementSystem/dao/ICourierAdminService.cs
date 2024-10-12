using CourierManagementSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.dao
{
    public interface ICourierAdminService
    {
        int AddCourierStaff(Employee obj);
    }
}
