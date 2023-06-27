using System;
using System.Collections.Generic;
using Shared.Models;
using Shared.Data;

namespace DisplayingDetailsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Displaying Details Application");

            DataRepository repository = new DataRepository();

            while (true)
            {
                Console.WriteLine("Analytics");
                Console.WriteLine("1. Number of users per location");
                Console.WriteLine("2. Number of users overall");
                Console.WriteLine("3. Number of clients created per date");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayUsersPerLocation(repository);
                        break;
                    case "2":
                        DisplayOverallUsers(repository);
                        break;
                    case "3":
                        DisplayClientsPerDate(repository);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayUsersPerLocation(DataRepository repository)
        {
            Console.WriteLine("Number of Users per Location");

            Dictionary<string, int> usersPerLocation = repository.GetUsersPerLocation();

            Console.WriteLine("Location\tNumber of Users");
            foreach (var item in usersPerLocation)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }

        static void DisplayOverallUsers(DataRepository repository)
        {
            Console.WriteLine("Number of Users Overall");

            int totalUsers = repository.GetTotalUsers();

            Console.WriteLine($"Total Users: {totalUsers}");
        }

        static void DisplayClientsPerDate(DataRepository repository)
        {
            Console.WriteLine("Number of Clients Created per Date");

            Dictionary<DateTime, int> clientsPerDate = repository.GetClientsPerDate();

            Console.WriteLine("Date\t\tNumber of Clients");
            foreach (var item in clientsPerDate)
            {
                Console.WriteLine($"{item.Key.ToShortDateString()}\t{item.Value}");
            }
        }
    }
}
