using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entitiy
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string contactNumber { get; set; }
        public string address { get; set; }
    }
}
