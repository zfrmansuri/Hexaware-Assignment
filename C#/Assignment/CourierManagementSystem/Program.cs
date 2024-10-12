using CourierManagementSystem.entity;
using CourierManagementSystem.dao;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourierManagementSystem.exception;
using CourierManagementSystem.util;
using System.Data.SqlClient;

namespace CourierManagementSystem
{
    internal class Program
    {
        // Employee and Customer credentials for login
        private static Dictionary<string, string> employeeCredentials = new Dictionary<string, string>
        {
            { "employee1", "password123" },
            { "employee2", "password456" }
        };

        private static Dictionary<string, string> customerCredentials = new Dictionary<string, string>
        {
            { "customer1", "pass789" },
            { "customer2", "pass012" }
        };

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\nChoose an Option: ");
                Console.WriteLine("1. View Order Status");
                Console.WriteLine("2. Classify Parcel by Weight");
                Console.WriteLine("3. Authenticate User");
                Console.WriteLine("4. Allocate Courier for Shipment");
                Console.WriteLine("5. Show Customer Orders");
                Console.WriteLine("6. Monitor Courier Location");
                Console.WriteLine("7. Log Tracking History");
                Console.WriteLine("8. Identify Nearest Available Courier");
                Console.WriteLine("9. Track Parcel Using 2D Array");
                Console.WriteLine("10. Verify Customer Information");
                Console.WriteLine("11. Standardize Address Format");
                Console.WriteLine("12. Create Order Confirmation Email");
                Console.WriteLine("13. Compute Shipping Cost");
                Console.WriteLine("14. Generate Strong Password");
                Console.WriteLine("15. Locate Similar Addresses");
                Console.WriteLine("16. Exception Handling");
                Console.WriteLine("17. Insert, Update, and Retrieve data from the database");
                Console.WriteLine("18. Exit\n");

                // Read user input
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            ViewOrderStatus();
                            break;
                        case 2:
                            ClassifyParcel();
                            break;
                        case 3:
                            AuthenticateUser();
                            break;
                        case 4:
                            AllocateCourier();
                            break;
                        case 5:
                            ShowCustomerOrders();
                            break;
                        case 6:
                            MonitorCourierLocation();
                            break;
                        case 7:
                            LogTrackingHistory();
                            break;
                        case 8:
                            IdentifyNearestCourier();
                            break;
                        case 9:
                            TrackParcelUsing2DArray();
                            break;
                        case 10:
                            VerifyCustomerInfo();
                            break;
                        case 11:
                            StandardizeAddress();
                            break;
                        case 12:
                            CreateOrderConfirmationEmail();
                            break;
                        case 13:
                            ComputeShippingCost();
                            break;
                        case 14:
                            GenerateStrongPassword();
                            break;
                        case 15:
                            LocateSimilarAddresses();
                            break;
                        case 16:
                            ImplementException();
                            break;
                        case 17:
                            DatabaseConnection();
                            break;
                        case 18:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            };

        }

        // Task-1: Qustion-1
        public static void ViewOrderStatus()
        {
            string orderStatus = "Delivered";

            // Check the status using if-else statements
            if (orderStatus.Equals("Processing", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order is currently being processed.");
            }
            else if (orderStatus.Equals("Delivered", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order has been delivered.");
            }
            else if (orderStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order has been cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid status. Please enter a valid order status (Processing, Delivered, Cancelled).");
            }
        }

        // Task-2: Question-2
        public static void ClassifyParcel()
        {
            decimal weight = 12;  // Parcel weight in kg
            string category = "";

            switch (weight)
            {
                case decimal n when (n <= 5):
                    category = "Light";
                    break;
                case decimal n when (n > 5 && n <= 15):
                    category = "Medium";
                    break;
                case decimal n when (n > 15):
                    category = "Heavy";
                    break;
                default:
                    category = "Unknown";
                    break;
            }
            Console.WriteLine($"The parcel is categorized as: {category}");
        }

        // Task-1: Question-3
        public static void AuthenticateUser()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (employeeCredentials.ContainsKey(username) && employeeCredentials[username] == password)
            {
                Console.WriteLine("Welcome Employee!");
            }
            else if (customerCredentials.ContainsKey(username) && customerCredentials[username] == password)
            {
                Console.WriteLine("Welcome Customer!");
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }

        //Task-1: Question-4
        public static void AllocateCourier()
        {
            // Array of available couriers
            string[] availableCouriers = { "Courier A", "Courier B", "Courier C" };
            // Corresponding proximity values in kilometers
            int[] courierProximity = { 10, 5, 15 };
            // Corresponding maximum load capacities in kilograms
            int[] courierLoadCapacity = { 20, 10, 30 };

            // Prompt the user for the weight of the shipment
            Console.WriteLine("\nPlease enter the weight of the shipment (in kg): ");
            int shipmentWeight;

            // Validate user input for shipment weight
            while (!int.TryParse(Console.ReadLine(), out shipmentWeight) || shipmentWeight < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the shipment weight:");
            }

            int selectedCourierIndex = -1; // Initialize selected courier index

            // Loop through the couriers to find a suitable one
            for (int index = 0; index < availableCouriers.Length; index++)
            {
                // Check if the courier can handle the shipment weight
                if (shipmentWeight <= courierLoadCapacity[index])
                {
                    // Assign courier based on proximity
                    if (selectedCourierIndex == -1 || courierProximity[index] < courierProximity[selectedCourierIndex])
                    {
                        selectedCourierIndex = index; // Update selected courier index
                    }
                }
            }

            // Display the result
            if (selectedCourierIndex != -1)
            {
                Console.WriteLine($"The shipment has been assigned to {availableCouriers[selectedCourierIndex]} (Proximity: {courierProximity[selectedCourierIndex]} km, Load Capacity: {courierLoadCapacity[selectedCourierIndex]} kg).");
            }
            else
            {
                Console.WriteLine("No available courier can handle this shipment.");
            }
        }

        // Task 2: Question- 5
        public static void ShowCustomerOrders()
        {
            Dictionary<string, List<string>> customerOrders = new Dictionary<string, List<string>>
            {
                { "Customer A", new List<string> { "Order1", "Order2", "Order3" } },
                { "Customer B", new List<string> { "Order4", "Order5" } },
                { "Customer C", new List<string> { "Order6" } }
            };

            Console.WriteLine("Enter the customer name to view their orders: ");
            string customerName = Console.ReadLine();

            if (customerOrders.ContainsKey(customerName))
            {
                List<string> orders = customerOrders[customerName];
                Console.WriteLine($"\nOrders for {customerName}:");

                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"Order {i + 1}: {orders[i]}");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        // Task 2: Question- 6
        public static void MonitorCourierLocation()
        {
            string[] locations = { "Warehouse", "Checkpoint 1", "Checkpoint 2", "Checkpoint 3", "Destination" };
            int currentIndex = 0;

            Console.WriteLine("Tracking courier's location...");

            while (currentIndex < locations.Length)
            {
                string currentLocation = locations[currentIndex];
                Console.WriteLine($"Courier is currently at: {currentLocation}");

                currentIndex++;
                System.Threading.Thread.Sleep(500);
            }

            Console.WriteLine("Courier has reached its destination!");
        }


        // Task 3: Question- 7
        public static void LogTrackingHistory()
        {
            string[] trackingHistory = new string[5];
            trackingHistory[0] = "Warehouse";
            trackingHistory[1] = "Checkpoint 1";
            trackingHistory[2] = "Checkpoint 2";
            trackingHistory[3] = "Checkpoint 3";
            trackingHistory[4] = "Delivered";

            Console.WriteLine("Tracking History of the Parcel:");
            for (int i = 0; i < trackingHistory.Length; i++)
            {
                Console.WriteLine($"Update {i + 1}: {trackingHistory[i]}");
            }
        }


        // Task 3: Question- 8
        public static void IdentifyNearestCourier()
        {
            string[] couriers = { "Courier A", "Courier B", "Courier C" };
            int[] distances = { 5, 10, 3 }; // Distances in km

            int minDistanceIndex = 0;

            for (int i = 1; i < distances.Length; i++)
            {
                if (distances[i] < distances[minDistanceIndex])
                {
                    minDistanceIndex = i;
                }
            }

            Console.WriteLine($"The nearest available courier is: {couriers[minDistanceIndex]}");
        }


        // Task 4: Question- 9
        public static void TrackParcelUsing2DArray()
        {
            // Initialize a 2D array with tracking numbers and statuses
            string[,] trackingData = {
                { "TRK001", "In Transit" },
                { "TRK002", "Out for Delivery" },
                { "TRK003", "Delivered" }
            };

            Console.WriteLine("Enter your parcel tracking number:");
            string inputTrackingNumber = Console.ReadLine();
            bool parcelFound = false;

            // Simulate the tracking process
            for (int i = 0; i < trackingData.GetLength(0); i++)
            {
                if (trackingData[i, 0].Equals(inputTrackingNumber, StringComparison.OrdinalIgnoreCase))
                {
                    parcelFound = true;
                    string status = trackingData[i, 1];

                    switch (status)
                    {
                        case "In Transit":
                            Console.WriteLine("Parcel is currently in transit.");
                            break;
                        case "Out for Delivery":
                            Console.WriteLine("Parcel is out for delivery.");
                            break;
                        case "Delivered":
                            Console.WriteLine("Parcel has been delivered.");
                            break;
                        default:
                            Console.WriteLine("Unknown status.");
                            break;
                    }
                    break;
                }
            }

            if (!parcelFound)
            {
                Console.WriteLine("Tracking number not found.");
            }
        }


        // Task 4: Question- 10
        public static void VerifyCustomerInfo()
        {
            // Sample data for validation
            string name = "Sharukh Khan";
            string address = "123 Mumbai South";
            string phoneNumber = "123-456-7890";

            // Validate name
            if (Regex.IsMatch(name, @"^[A-Z][a-z]+\s[A-Z][a-z]+$"))
            {
                Console.WriteLine("Valid name.");
            }
            else
            {
                Console.WriteLine("Invalid name. Names should be properly capitalized and contain only letters.");
            }

            // Validate address
            if (Regex.IsMatch(address, @"^[A-Za-z0-9\s]+$"))
            {
                Console.WriteLine("Valid address.");
            }
            else
            {
                Console.WriteLine("Invalid address. Addresses should not contain special characters.");
            }

            // Validate phone number
            if (Regex.IsMatch(phoneNumber, @"^\d{3}-\d{3}-\d{4}$"))
            {
                Console.WriteLine("Valid phone number.");
            }
            else
            {
                Console.WriteLine("Invalid phone number. Phone numbers should follow the format ###-###-####.");
            }
        }


        // Task 4: Question- 11
        public static void StandardizeAddress()
        {
            Console.WriteLine("Street Name: ");
            string street = Console.ReadLine();
            Console.WriteLine("City Name: ");
            string city = Console.ReadLine();
            Console.WriteLine("State Name: ");
            string state = Console.ReadLine();
            Console.WriteLine("Your zip code: ");
            string zip = Console.ReadLine();

            string formattedAddress = $"{Capitalize(street)}, {Capitalize(city)}, {Capitalize(state)}, {zip}";
            Console.WriteLine($"Formatted Address: {formattedAddress}");
        }
        static string Capitalize(string input)
        {
            return string.Join(" ", input.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }


        // Task 4: Question- 12
        public static void CreateOrderConfirmationEmail()
        {
            Console.WriteLine("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter Order Number: ");
            string orderNumber = Console.ReadLine();

            Console.WriteLine("Enter Delivery Address: ");
            string deliveryAddress = Console.ReadLine();

            Console.WriteLine("Enter Expected Delivery Date (MM/dd/yyyy): ");
            string deliveryDate = Console.ReadLine();

            string orderConfirmationEmail =
                $"Dear {customerName},\n\n" +
                $"Thank you for your order! Here are your order details:\n" +
                $"Order Number: {orderNumber}\n" +
                $"Delivery Address: {deliveryAddress}\n" +
                $"Expected Delivery Date: {deliveryDate}\n\n" +
                $"We appreciate your business and look forward to serving you again.\n\n" +
                $"Best Regards,\n" +
                $"Courier Management System";

            Console.WriteLine("\nOrder Confirmation Email:");
            Console.WriteLine(orderConfirmationEmail);
        }


        // Task 4: Question- 13
        public static void ComputeShippingCost()
        {
            Console.WriteLine("Enter Source Address: ");
            string sourceAddress = Console.ReadLine();

            Console.WriteLine("Enter Destination Address: ");
            string destinationAddress = Console.ReadLine();

            Console.WriteLine("Enter Distance (in km): ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Parcel Weight (in kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            double shippingCost = CalculateShippingCost(distance, weight);

            Console.WriteLine($"\nShipping Cost from {sourceAddress} to {destinationAddress}: ${shippingCost:F2}");
        }
        private static double CalculateShippingCost(double distance, double weight)
        {
            const double costPerKm = 0.5; // Cost per kilometer
            const double weightFactor = 2.0; // Cost factor per kg

            double cost = (distance * costPerKm) + (weight * weightFactor);
            return cost;
        }


        // Task 4: Question- 14
        public static void GenerateStrongPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+<>?";
            Random random = new Random();
            int passwordLength = 12;
            char[] password = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            Console.WriteLine($"Generated secure password: {new string(password)}");
        }


        // Task 4: Question- 15
        public static void LocateSimilarAddresses()
        {
            string[] addresses = {
                "123 Main St, Springfield, IL",
                "456 Elm St, Springfield, IL",
                "789 Maple Ave, Springfield, IL",
                "123 Main St, Springfield, IL",
            };

            var uniqueAddresses = new HashSet<string>();
            foreach (var address in addresses)
            {
                if (!uniqueAddresses.Add(address.ToLower()))
                    Console.WriteLine($"Similar address is :{address}");
            }
        }

        //Task 7 : Exception Handling
        static void ImplementException()
        {
            ICourierUserService userService = new CourierUserService();

            try
            {
                // Example: Placing an order
                var newCourier = new Courier
                {
                    SenderName = "John Doe",
                    SenderAddress = "123 Main St",
                    ReceiverName = "Jane Smith",
                    ReceiverAddress = "456 Elm St",
                    Weight = 5.0,
                    Status = "yetToTransit",
                    DeliveryDate = DateTime.Now.AddDays(3)
                };
                string trackingNumber = userService.PlaceOrder(newCourier);
                Console.WriteLine($"Order placed successfully! Tracking Number: {trackingNumber}");

                // Example: Get order status (exception will be thrown if the tracking number is invalid)
                string status = userService.GetOrderStatus(trackingNumber);
                Console.WriteLine($"Order Status: {status}");

            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of program.");
            }
        }


        //Task-9
        //Database Connection nd insert, update, and retrieve data from the database
        static void DatabaseConnection()
        {
            // Create an instance of CourierServiceDb to interact with the database
            CourierServiceDb courierService = new CourierServiceDb();

            //Inserting a new courier order
            Courier newCourier = new Courier
            {
                SenderName = "Zafar Mansuri",
                SenderAddress = "123 Ujjain Tower",
                ReceiverName = "Raj Patel",
                ReceiverAddress = "456 Indore Vijay Nagar",
                Weight = 2.5,
                Status = "yetToTransit",
                TrackingNumber = "TR12345",
                DeliveryDate = DateTime.Now.AddDays(3)
            };

            courierService.InsertCourier(newCourier);

            //Updating courier status
            string trackingNumber = "TR12345";
            string newStatus = "In Transit";
            courierService.UpdateCourierStatus(trackingNumber, newStatus);

            // Example: Retrieving courier details by tracking number
            Courier courier = courierService.GetCourierByTrackingNumber(trackingNumber);
            if (courier != null)
            {
                Console.WriteLine($"Courier {courier.CourierID}: {courier.SenderName} -> {courier.ReceiverName}, Status: {courier.Status}");
            }
        }

    }
}
