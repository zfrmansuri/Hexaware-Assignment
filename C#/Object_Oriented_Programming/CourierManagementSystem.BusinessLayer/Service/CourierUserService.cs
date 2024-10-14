using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Service
{
    public class CourierUserService : ICourierUserService
    {
        private List<Courier> courierOrders = new List<Courier>(); 

        // Placecourier order and return a unique tracking number
        public string PlaceOrder(Courier courierObj)
        {
            courierOrders.Add(courierObj);
            return courierObj.TrackingNumber;
        }

        // Get the status of a courier order based on tracking number
        public string GetOrderStatus(string trackingNumber)
        {
            Courier order = courierOrders.Find(c => c.TrackingNumber == trackingNumber);
            if (order != null)
            {
                return order.status;
            }
            return "Order not found";
        }

        // Cancel a courier order
        public bool CancelOrder(string trackingNumber)
        {
            Courier order = courierOrders.Find(c => c.TrackingNumber == trackingNumber);
            if (order != null && order.status != "Delivered")
            {
                courierOrders.Remove(order);
                return true;
            }
            return false;
        }

        // Get a list of orders assigned to a specific courier staff member
        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            // Assuming `userId` represents the courier staff ID
            return courierOrders.FindAll(c => c.employeeID == courierStaffId);
        }
    }
}
