using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Custom_Exceptions
{
    public class TrackingNumberNotFoundException : RankException
    {
        // Default 
        public TrackingNumberNotFoundException() : base("Tracking number not found.")
        {
        }

        // Custom message
        public TrackingNumberNotFoundException(string message) : base(message)
        {
        }

        // Custom message and an inner exception
        public TrackingNumberNotFoundException(string message, RankException inner) : base(message, inner)
        {
        }
    }
}
