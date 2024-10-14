using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        public PaymentRepository() { }

        //Parameterized constructor
        Payment payment = new Payment();

        public PaymentRepository(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            payment.paymentID = paymentID;
            payment.courierID = courierID;
            payment.amount = amount;
            payment.paymentDate = paymentDate;


        }

        public override string ToString()
        {
            return $"Payment {{ paymentID={payment.paymentID}, courierID='{payment.courierID}', amount='{payment.amount}', " +
                   $"paymentDate='{payment.paymentDate}' }}";

        }
        public void DisplayPaymentInfo()
        {
            Console.WriteLine($"{payment.paymentID}, {payment.courierID},{payment.amount},{payment.paymentDate}");
        }


    }
}

