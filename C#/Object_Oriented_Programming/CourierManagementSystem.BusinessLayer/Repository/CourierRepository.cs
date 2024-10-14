using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Repository
{
    public class CourierRepository : ICourierRepository
    {
        public CourierRepository() { }

        //Parameterized constructor
        Courier courier = new Courier();

        public CourierRepository(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, string trackingNumber, DateTime deliveryDate, int employeeID)
        {
            courier.courierID = courierID;
            courier.senderName = senderName;
            courier.senderAddress = senderAddress;
            courier.receiverAddress = receiverAddress;

            courier.weight = weight;
            courier.status = status;
            //courier.TrackingNumber = trackingNumber;
            courier.deliveryDate = deliveryDate;
            courier.employeeID= employeeID;

        }
        public override string ToString()
        {
            return $"Employee {{ courierID={courier.courierID}, SenderName='{courier.senderName}', senderAddress='{courier.senderAddress}', " +
                   $"receiverAddress='{courier.receiverAddress}', weight='{courier.weight}', status={courier.status}' , deliveryDate='{courier.deliveryDate}', employeeID='{courier.employeeID}'}} ";

        }

        public void DisplayCourierInfo()
        {
            Console.WriteLine($"{courier.courierID}, {courier.senderName},{courier.senderAddress},{courier.receiverAddress},{courier.weight},{courier.status} , {courier.deliveryDate}, {courier.employeeID} ");
        }
    }
}
