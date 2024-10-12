using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.entity
{
    public class Courier
    {
        private static int trackingNumberCounter = new Random().Next(1000, 9999); // Random starting tracking number

        public int CourierID { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get;  set; }
        public DateTime DeliveryDate { get; set; }
        public int UserId { get; set; }

        // Default Constructor
        public Courier()
        {
            TrackingNumber = GenerateTrackingNumber(); // Generate unique tracking number upon creation
        }

        // Parameterized Constructor
        public Courier(int courierID, string senderName, string senderAddress, string receiverName,
                       string receiverAddress, double weight, string status, DateTime deliveryDate, int userId)
        {
            CourierID = courierID;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            Weight = weight;
            Status = status;
            TrackingNumber = GenerateTrackingNumber(); // Generate unique tracking number upon creation
            DeliveryDate = deliveryDate;
            UserId = userId;
        }

        private string GenerateTrackingNumber()
        {
            return "TRACK" + trackingNumberCounter++; // Increment tracking number for the next Courier
        }

        // ToString Method
        public override string ToString()
        {
            return $"CourierID: {CourierID}, SenderName: {SenderName}, ReceiverName: {ReceiverName}, Weight: {Weight}, Status: {Status}, TrackingNumber: {TrackingNumber}";
        }
    }
}
