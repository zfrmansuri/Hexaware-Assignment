using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.entity
{
    public class Location
    {
        private int locationID;
        private string locationName;
        private string address;

        // Default Constructor
        public Location() { }

        // Parameterized Constructor
        public Location(int locationID, string locationName, string address)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.address = address;
        }

        // Getters and Setters
        public int LocationID { get => locationID; set => locationID = value; }
        public string LocationName { get => locationName; set => locationName = value; }
        public string Address { get => address; set => address = value; }

        // ToString Method
        public override string ToString()
        {
            return $"LocationID: {locationID}, LocationName: {locationName}, Address: {address}";
        }
    }
}
