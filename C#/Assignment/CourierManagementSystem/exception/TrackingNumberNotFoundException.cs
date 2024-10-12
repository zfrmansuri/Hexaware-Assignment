using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.exception
{
    public class TrackingNumberNotFoundException : ApplicationException
    {
        public TrackingNumberNotFoundException(string message) : base(message)
        {
        }
    }
}
