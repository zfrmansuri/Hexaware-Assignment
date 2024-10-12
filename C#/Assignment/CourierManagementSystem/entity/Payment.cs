using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.entity
{
    public class Payment
    {
        private long paymentID;
        private long courierID;
        private double amount;
        private DateTime paymentDate;

        // Default Constructor
        public Payment() { }

        // Parameterized Constructor
        public Payment(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.courierID = courierID;
            this.amount = amount;
            this.paymentDate = paymentDate;
        }

        // Getters and Setters
        public long PaymentID { get => paymentID; set => paymentID = value; }
        public long CourierID { get => courierID; set => courierID = value; }
        public double Amount { get => amount; set => amount = value; }
        public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }

        // ToString Method
        public override string ToString()
        {
            return $"PaymentID: {paymentID}, CourierID: {courierID}, Amount: {amount}, PaymentDate: {paymentDate}";
        }
    }
}
