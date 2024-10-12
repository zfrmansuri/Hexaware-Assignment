using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.entity
{
    internal class User
    {
        private int userID;
        private string userName;
        private string email;
        private string password;
        private string contactNumber;
        private string address;

        // Default Constructor
        public User() { }

        // Parameterized Constructor
        public User(int userID, string userName, string email, string password, string contactNumber, string address)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        // Getters and Setters
        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Address { get => address; set => address = value; }

        // ToString Method
        public override string ToString()
        {
            return $"UserID: {userID}, UserName: {userName}, Email: {email}, ContactNumber: {contactNumber}, Address: {address}";
        }
    }
}
