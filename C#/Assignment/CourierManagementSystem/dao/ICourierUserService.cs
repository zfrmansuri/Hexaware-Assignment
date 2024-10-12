using CourierManagementSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.dao
{
    public abstract class ICourierUserService
    {
        public abstract string PlaceOrder(Courier courierObj);
        public abstract string GetOrderStatus(string trackingNumber);
        public abstract bool CancelOrder(string trackingNumber);
        public abstract List<Courier> GetAssignedOrders(int courierStaffId);
    }
}
