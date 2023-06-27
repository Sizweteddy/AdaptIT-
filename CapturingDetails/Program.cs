using System;
using Shared.Data;
using Shared.Models;

namespace CapturingDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository dataRepository = new DataRepository();

            Console.WriteLine("Enter client details:");
            Console.Write("Client Name: ");
            string clientName = Console.ReadLine();

            Console.Write("Date Registered (yyyy-MM-dd): ");
            DateTime dateRegistered = DateTime.Parse(Console.ReadLine());

            Console.Write("Location: ");
            string location = Console.ReadLine();

            Console.Write("Number of Users: ");
            int numberOfUsers = int.Parse(Console.ReadLine());

            Client client = new Client
            {
                ClientName = clientName,
                DateRegistered = dateRegistered,
                Location = location,
                NumberOfUsers = numberOfUsers
            };

            dataRepository.AddClient(client);
            dataRepository.SaveData();

            Console.WriteLine("Client details captured successfully!");

            Console.WriteLine();
            Console.WriteLine("Users per Location:");
            var usersPerLocation = dataRepository.GetUsersPerLocation();
            foreach (var kvp in usersPerLocation)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} users");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Users: {dataRepository.GetTotalUsers()}");

            Console.WriteLine();
            Console.WriteLine("Clients per Date:");
            var clientsPerDate = dataRepository.GetClientsPerDate();
            foreach (var kvp in clientsPerDate)
            {
                Console.WriteLine($"{kvp.Key:yyyy-MM-dd}: {kvp.Value} clients");
            }
        }
    }
}
