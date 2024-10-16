using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entitiy
{
    public class Courier
    {
        public long courierID { get; set; }
        public string senderName { get; set; }
        public string senderAddress { get; set; }
        public string receiverName { get; set; }
        public string receiverAddress { get; set; }
        public double weight { get; set; }
        public string status { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime deliveryDate { get; set; }
        public int employeeID { get; set; }
    }
}
