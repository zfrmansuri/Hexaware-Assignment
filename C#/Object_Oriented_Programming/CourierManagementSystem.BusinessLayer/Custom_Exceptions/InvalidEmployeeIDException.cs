using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Custom_Exceptions
{
    public  class InvalidEmployeeIDException : RankException
    {
        public InvalidEmployeeIDException() : base("Invalid employee ID entered.")
        {
        }

        public InvalidEmployeeIDException(string message) : base(message)
        {
        }

        public InvalidEmployeeIDException(string message, RankException inner) : base(message, inner)
        {
        }
    }
}
