using CourierManagementSystem.entity;
using CourierManagementSystem.exception;
using System;
using System.Collections.Generic;

namespace CourierManagementSystem.dao
{
    public class CourierUserService : ICourierUserService
    {
        private List<Courier> couriers = new List<Courier>();

        // Place an order and return the tracking number
        public override string PlaceOrder(Courier courierObj)
        {
            couriers.Add(courierObj);
            return courierObj.TrackingNumber; // Return the tracking number
        }

        // Get the status of a specific order by its tracking number
        public override string GetOrderStatus(string trackingNumber)
        {
            // Find the order by tracking number
            var order = couriers.Find(c => c.TrackingNumber == trackingNumber);

            // If order is not found, throw custom exception
            if (order == null)
            {
                throw new TrackingNumberNotFoundException($"Tracking number {trackingNumber} not found.");
            }

            return order.Status;
        }

        // Cancel an order by its tracking number
        public override bool CancelOrder(string trackingNumber)
        {
            // Find the order by tracking number
            var order = couriers.Find(c => c.TrackingNumber == trackingNumber);

            // If order is not found, throw exception
            if (order == null)
            {
                throw new TrackingNumberNotFoundException($"Tracking number {trackingNumber} not found.");
            }

            // If order is found, remove it from the list and cancel the order
            couriers.Remove(order);
            return true; // Order successfully canceled
        }

        // Get the list of orders assigned to a specific courier staff member
        public override List<Courier> GetAssignedOrders(int courierStaffId)
        {
            // Logic to get assigned orders for the specific courier staff member
            // For now, we will return all orders as a placeholder
            return couriers;
        }
    }
}
