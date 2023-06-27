using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Shared.Models;

namespace Shared.Data
{
    public class DataRepository
    {
        private readonly string dataFilePath =  "./Clients.json";
        private List<Client> clients;

        public DataRepository()
        {
            LoadData();
        }

        public void AddClient(Client client)
        {
            if (clients.Find(c => c.ClientName == client.ClientName) != null)
            {
                Console.WriteLine("Client with the same name already exists. Please try again.");
                return;
            }

            clients.Add(client);
        }

        public Dictionary<string, int> GetUsersPerLocation()
        {
            Dictionary<string, int> usersPerLocation = new Dictionary<string, int>();

            foreach (var client in clients)
            {
                if (usersPerLocation.ContainsKey(client.Location))
                    usersPerLocation[client.Location] += client.NumberOfUsers;
                else
                    usersPerLocation[client.Location] = client.NumberOfUsers;
            }

            return usersPerLocation;
        }

        public int GetTotalUsers()
        {
            int totalUsers = 0;

            foreach (var client in clients)
            {
                totalUsers += client.NumberOfUsers;
            }

            return totalUsers;
        }

        public Dictionary<DateTime, int> GetClientsPerDate()
        {
            Dictionary<DateTime, int> clientsPerDate = new Dictionary<DateTime, int>();

            foreach (var client in clients)
            {
                DateTime date = client.DateRegistered.Date;

                if (clientsPerDate.ContainsKey(date))
                    clientsPerDate[date]++;
                else
                    clientsPerDate[date] = 1;
            }

            return clientsPerDate;
        }

       public void SaveData()
{
    string jsonData = JsonConvert.SerializeObject(clients, Formatting.Indented);
    File.WriteAllText(dataFilePath, jsonData);
}


        private void LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                string jsonData = File.ReadAllText(dataFilePath);
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
            }
            else
            {
                // Initialize clients list with seed data
                clients = new List<Client>
                {
                    new Client
                    {
                        ClientName = "Client A",
                        DateRegistered = DateTime.Parse("2022-01-01"),
                        Location = "Location X",
                        NumberOfUsers = 10
                    },
                    new Client
                    {
                        ClientName = "Client B",
                        DateRegistered = DateTime.Parse("2022-02-01"),
                        Location = "Location Y",
                        NumberOfUsers = 5
                    }
                    // Add more seed data if needed
                };
            }
        }
    }
}
