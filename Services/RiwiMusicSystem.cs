using riwiMusic.Models;
using System;
using System.Collections.Generic;

namespace riwiMusic.Services
{
    public class RiwiMusicSystem
    {
        // Vamos a usar listas en memoria para almacenar los datos
        private List<Concert> concerts = new List<Concert>();
        private List<Client> clients = new List<Client>();
        private List<Ticket> tickets = new List<Ticket>();
        
        // Creamos contadores para los IDs
        private int nextConcertId = 1;
        private int nextClientId = 1;
        private int nextTicketId = 1;

        // cremos los metodos para cada módulo

        public void ManageConcerts()
        {
            // Submenu with options to manage concerts (list, create, update, delete)
            bool exitApp = false;
            while (!exitApp)
            {
                //Console.Clear();
                Console.WriteLine("===== Concert management =====");
                Console.WriteLine("1. List concerts");
                Console.WriteLine("2. Add concert");
                Console.WriteLine("3. Update concert");
                Console.WriteLine("4. Delete concert");
                Console.WriteLine("5. View concert details");
                Console.WriteLine("6. Leave this menu");
                Console.Write("Please, choose an option: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        ListConcerts();
                        break;
                    case "2":
                        AddConcert();
                        break;
                    case "3":
                        UpdateConcert();
                        break;
                    case "4":
                        DeleteConcert();
                        break;
                    case "5":
                        ViewConcertDetails();
                        break;
                    case "6":
                        exitApp = true;
                        Console.WriteLine("Thanks for using RiwiMusic. See you soon!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        //List concerts
        public void ListConcerts(){}
        
        //Add concerts
        public void AddConcert()
        {
            //Console.Clear();
            Console.WriteLine("===== Add Concert =====");
            string name = EmptyInput("Name: ");
            string city = EmptyInput("City: ");
            DateTime date = ValidDateInput("Date: ");
            int totalCapacity = TotalCapacityInput("Capacity: ");
            Concert newConcert = new Concert();
            newConcert.Id = nextConcertId;
            newConcert.Name = name;
            newConcert.Date = date;
            newConcert.City = city;
            newConcert.TotalCapacity = totalCapacity;
            concerts.Add(newConcert);
            Console.WriteLine("Concert added");
            foreach (Concert concert in concerts)
            {
                Console.WriteLine($"Id: {concert.Id}\nName: {concert.Name} \nCity: {concert.City} \nDate: {concert.Date} \nCapacity: {concert.TotalCapacity}");
            }
            nextConcertId++;
        }
        
        //Update concert
        public void UpdateConcert(){}
        
        //Delete concert
        public void DeleteConcert(){}
        
        //View concert details
        public void ViewConcertDetails(){}
        
        //Input methods
        public string EmptyInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine()?.Trim();
                if (!String.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Value required. Try again.");
                }
            }
        }
        public DateTime ValidDateInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()?.Trim();
                if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid date. Try again.");
                }
            }
        }

        public int TotalCapacityInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine()?.Trim();
                if (int.TryParse(input, out int capacity))
                {
                    return capacity;
                }
                else
                {
                    Console.WriteLine("Invalid number. Try again.");
                }
            }
        }
        

        public void ManageClients()
        {
            Console.WriteLine("Módulo de Clientes - Lógica a implementar por Persona 3.");
            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        public void ManageTickets()
        {
            Console.WriteLine("Módulo de Tiquetes - Lógica a implementar por Persona 3.");
            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }
        
        public void ShowPurchaseHistory()
        {
            Console.WriteLine("Módulo de Historial - Lógica a implementar por Persona 4.");
            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        public void RunAdvancedQueries()
        {
            Console.WriteLine("Módulo de Consultas LINQ - Lógica a implementar por Persona 4.");
            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }
    }
}