using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entitiy;

namespace CourierManagementSystem.BusinessLayer.Repository
{
    public class UserRepository : IUserRepository

    {
        // Default constructor
        public UserRepository() { }

        //Parameterized constructor
        User user = new User();
        public UserRepository(int userID, string userName, string email, string password, string contactNumber, string address)
        {
            user.userID = userID;
            user.userName = userName;
            user.email = email;
            user.password = password;
            user.contactNumber = contactNumber;
            user.address = address;
         
        }
        public override string ToString()
        {
            return $"User {{ userID={user.userID}, userName='{user.userName}', email='{user.email}', " +
                   $"password='{user.password}', contactNumber=''{user.contactNumber}',address={user.address} }}";

        }
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"{user.userID}, {user.userName},{user.email},{user.password},{user.contactNumber},{user.address}");
        }
    }
}