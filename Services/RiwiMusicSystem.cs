using riwiMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void ListConcerts()
        {
            if (concerts.Count() != 0)
            {
                Console.WriteLine("List of concerts:");
                var concertsList = concerts.Select(concert => concert.Name);
                foreach (var concert in concertsList)
                {
                    Console.WriteLine(concert);
                }
            }
            else
            {
                Console.WriteLine("There is no concerts on the list.");
            }
        }
        
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
        public void UpdateConcert()
        {
            if (concerts.Count != 0)
            {
                string concertToUpdateInput = EmptyInput("Name of the concert: ");
                var concertToUpdate = concerts.FirstOrDefault(concert => concert.Name == concertToUpdateInput);
                if (concertToUpdate != null)
                {
                    Console.WriteLine("Enter the new information (leave blank to keep current)");
                    Console.WriteLine("New name: ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        concertToUpdate.Name = newName;
                    }
                    Console.WriteLine("New city: ");
                    string newCity =  Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCity))
                    {
                        concertToUpdate.City = newCity;
                    }
                    Console.WriteLine("New date: ");
                    string newDateInput =  Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDateInput))
                    {
                        if (DateTime.TryParse(newDateInput, out DateTime newDate))
                        {
                            concertToUpdate.Date = newDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date.");
                        }
                    }
                    Console.WriteLine("New total capacity: ");
                    string newTotalCapacityInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTotalCapacityInput))
                    {
                        if (int.TryParse(newTotalCapacityInput, out int newTotalCapacity))
                        {
                            concertToUpdate.TotalCapacity = newTotalCapacity;
                        }
                    }
                    Console.WriteLine("Concert updated");
                    foreach (Concert concert in concerts)
                    {
                        Console.WriteLine($"Id: {concert.Id}\nName: {concert.Name} \nCity: {concert.City} \nDate: {concert.Date} \nCapacity: {concert.TotalCapacity}");
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't find that concert.");
                }
               
            }
            else
            {
                Console.WriteLine("There is no concerts on the list.");
            }
        }
        
        //Delete concert
        public void DeleteConcert()
        {
            if (concerts.Count != 0)
            {
                string concertToDeleteInput = EmptyInput("Name of the concert: ");
                var concertToDelete = concerts.FirstOrDefault(concert => concert.Name == concertToDeleteInput);
                if (concertToDelete != null)
                {
                    concerts.Remove(concertToDelete);
                    Console.WriteLine("Concert deleted");
                    if (concerts.Count != 0)
                    {
                        foreach (Concert concert in concerts)
                        {
                            Console.WriteLine($"Id: {concert.Id}\nName: {concert.Name} \nCity: {concert.City} \nDate: {concert.Date} \nCapacity: {concert.TotalCapacity}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no concerts on the list.");
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't find that concert.");
                }
            }
            else
            {
                Console.WriteLine("There is no concerts on the list.");
            }
        }
        
        //View concert details
        public void ViewConcertDetails()
        {
            if (concerts.Count != 0)
            {
                string concertToShowInput = EmptyInput("Name of the concert: ");
                var concertToShow = concerts.FirstOrDefault(concert => concert.Name == concertToShowInput);
                if (concertToShow != null)
                {
                    Console.WriteLine($"Id: {concertToShow.Id}\nName: {concertToShow.Name} \nCity: {concertToShow.City} \nDate: {concertToShow.Date} \nCapacity: {concertToShow.TotalCapacity}");
                }
                else
                {
                    Console.WriteLine("Couldn't find that concert.");
                }
            }
            else
            {
                Console.WriteLine("There is no concerts on the list.");
            }
        }
        
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
                string input = Console.ReadLine()?.Trim().ToLower();
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
            bool exitModule = false;

            while (!exitModule)
            {
                Console.Clear();
                Console.WriteLine("===== Gestión de Clientes =====");
                Console.WriteLine("1. Registrar nuevo cliente");
                Console.WriteLine("2. Listar todos los clientes");
                Console.WriteLine("3. Editar un cliente");
                Console.WriteLine("4. Eliminar un cliente");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        // --- REGISTRAR CLIENTE ---
                        Console.WriteLine("--- Registrar Nuevo Cliente ---");

                        // Validamos el nombre, que no esté vacío.
                        string clientName;
                        while (true)
                        {
                            Console.Write("Nombre del cliente: ");
                            clientName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(clientName))
                            {
                                break; 
                            }
                            Console.WriteLine("Error: El nombre no puede estar vacío.");
                        }
                        
                        string clientCedula;
                        while (true)
                        {
                            Console.Write("Cédula del cliente: ");
                            clientCedula = Console.ReadLine();
    
                            // Verificamos que no esté vacía
                            if (string.IsNullOrEmpty(clientCedula))
                            {
                                Console.WriteLine("Error: La cédula no puede estar vacía.");
                                continue;
                            }

                            // Verificamos que no exista ya un cliente con esa cédula
                            bool cedulaExists = false;
                            foreach (Client c in clients)
                            {
                                if (c.Cedula == clientCedula)
                                {
                                    cedulaExists = true;
                                    break;
                                }
                            }

                            if (cedulaExists)
                            {
                                Console.WriteLine("Error: Ya existe un cliente con esa cédula.");
                            }
                            else
                            {
                                break; // La cédula es válida y única, salimos del bucle
                            }
                        }

                        // Validamos el correo, que tenga inmeerso el @
                        string clientEmail;
                        while (true)
                        {
                            Console.Write("Email del cliente: ");
                            clientEmail = Console.ReadLine();
                            if (!string.IsNullOrEmpty(clientEmail) && clientEmail.Contains("@"))
                            {
                                break; 
                            }
                            Console.WriteLine("Error: El email no es válido o está vacío.");
                        }
                        
                        Client newClient = new Client(nextClientId, clientCedula, clientName, clientEmail);
                        clients.Add(newClient);
                        nextClientId++; // aqui ponemos una especie de contador que se incrementa cada vez.

                        Console.WriteLine("¡Cliente registrado con éxito!");
                        break;

                    case "2":
                        // --- LISTAR CLIENTES ---
                        Console.WriteLine("--- Lista de Clientes Registrados ---");
                        if (clients.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                        }
                        else
                        {
                            foreach (Client client in clients)
                            {
                                client.ShowInfo();
                            }
                        }
                        break;

                    case "3":
                        // --- EDITAR CLIENTE ---
                        Console.WriteLine("--- Editar Información del Cliente ---");
                        if (clients.Count == 0)
                        {
                            Console.WriteLine("No hay clientes para editar.");
                            break;
                        }
                        
                        Console.Write("Ingrese la Cédula del cliente que desea editar: ");
                        string cedulaToEdit = Console.ReadLine();

                        Client clientToEdit = null;
                        foreach (Client client in clients)
                        {
                            if (client.Cedula == cedulaToEdit)
                            {
                                clientToEdit = client;
                                break;
                            }
                        }

                        if (clientToEdit == null)
                        {
                            Console.WriteLine("Error: No se encontró un cliente con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine($"Editando cliente: {clientToEdit.Name}");
                            Console.WriteLine("Deje el campo vacío y presione Enter para no cambiar el valor.");

                            // Editar nombre con validación
                            while (true)
                            {
                                Console.Write($"Nuevo nombre ({clientToEdit.Name}): ");
                                string newName = Console.ReadLine();
                                if (string.IsNullOrEmpty(newName))
                                {
                                    break; // omitimos en caso de no cambiar el nombre
                                }
                                clientToEdit.Name = newName;
                                break;
                            }

                            // Editar email con validación
                            while (true)
                            {
                                Console.Write($"Nuevo email ({clientToEdit.Email}): ");
                                string newEmail = Console.ReadLine();
                                if (string.IsNullOrEmpty(newEmail))
                                {
                                    break; // No se cambia el email
                                }
                                if (newEmail.Contains("@"))
                                {
                                    clientToEdit.Email = newEmail;
                                    break;
                                }
                                Console.WriteLine("Error: El formato del email no es válido.");
                            }
                            
                            Console.WriteLine("¡Cliente actualizado con éxito!");
                        }
                        break;
                        
                    case "4":
                        // Eliminar cliente
                        Console.WriteLine("--- Eliminar Cliente ---");
                        if (clients.Count == 0)
                        {
                            Console.WriteLine("No hay clientes para eliminar.");
                            break;
                        }

                        Console.Write("Ingrese el ID del cliente que desea eliminar: ");
                        string cedulaToDelete = Console.ReadLine();

                        Client clientToDelete = null;
                        foreach (Client client in clients)
                        {
                            if (client.Cedula == cedulaToDelete)
                            {
                                clientToDelete = client;
                                break;
                            }
                        }

                        if (clientToDelete == null)
                        {
                            Console.WriteLine("Error: No se encontró un cliente con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine($"Cliente a eliminar: ID: {clientToDelete.Id}, Nombre: {clientToDelete.Name}");
                            Console.Write("¿Está seguro de que desea eliminarlo? (S/N): ");
                            string confirmation = Console.ReadLine();

                            if (confirmation.ToUpper() == "S")
                            {
                                clients.Remove(clientToDelete);
                                Console.WriteLine("Cliente eliminado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                        }
                        break;

                    case "5":
                        exitModule = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
                
                // Antes de salir, que presione Enter el usuario para continuar
                if (!exitModule)
                {
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }

        public void ManageTickets()
        {
            bool exitModule = false;
            while (!exitModule)
            {
                Console.Clear();
                Console.WriteLine("===== Gestión de Tiquetes =====");
                Console.WriteLine("1. Registrar compra de tiquete");
                Console.WriteLine("2. Listar tiquetes vendidos");
                Console.WriteLine("3. Editar compra (cambiar cliente)");
                Console.WriteLine("4. Eliminar compra");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        //REGISTRAR COMPRA 
                        Console.WriteLine("--- Registrar Nueva Compra de Tiquete ---");
                        
                        // validamos que existan conciertos y clientes
                        if (concerts.Count == 0 || clients.Count == 0)
                        {
                            Console.WriteLine("Error: Debe registrar al menos un concierto y un cliente antes de vender un tiquete.");
                            break;
                        }

                        // Pedimos el ID del concierto y se valida que exista 
                        Console.Write("Ingrese el ID del concierto: ");
                        int concertId = Convert.ToInt32(Console.ReadLine());
                        
                        Concert selectedConcert = null;
                        foreach (var concert in concerts)
                        {
                            if (concert.Id == concertId)
                            {
                                selectedConcert = concert;
                                break;
                            }
                        }

                        if (selectedConcert == null)
                        {
                            Console.WriteLine("Error: No se encontró un concierto con ese ID.");
                            break;
                        }

                        // Validar la capacidad del concierto
                        int ticketsSold = 0;
                        foreach (var ticket in tickets)
                        {
                            if (ticket.ConcertId == concertId)
                            {
                                ticketsSold++;
                            }
                        }

                        if (ticketsSold >= selectedConcert.TotalCapacity)
                        {
                            Console.WriteLine("Error: No hay más cupos disponibles para este concierto.");
                            break;
                        }

                        // Pedir y validar el ID del cliente
                        Console.Write("Ingrese el ID del cliente que realiza la compra: ");
                        int clientId = Convert.ToInt32(Console.ReadLine());

                        Client selectedClient = null;
                        foreach (var client in clients)
                        {
                            if (client.Id == clientId)
                            {
                                selectedClient = client;
                                break;
                            }
                        }

                        if (selectedClient == null)
                        {
                            Console.WriteLine("Error: No se encontró un cliente con ese ID.");
                            break;
                        }

                        //Si todo es correcto, registramos la compra
                        Ticket newTicket = new Ticket(nextTicketId, concertId, clientId);
                        nextTicketId++;

                        Console.WriteLine("¡Compra registrada con éxito!");
                        Console.WriteLine($"Tiquete ID: {newTicket.Id} para el concierto '{selectedConcert.Name}' a nombre de '{selectedClient.Name}'.");
                        break;

                    case "2":
                        // LISTAR TIQUETES 
                        Console.WriteLine("--- Lista de Tiquetes Vendidos ---");
                        if (tickets.Count == 0)
                        {
                            Console.WriteLine("No se han vendido tiquetes.");
                        }
                        else
                        {
                            foreach (var ticket in tickets)
                            {
                                // Para mostrar info útil, buscamos el nombre del concierto y del cliente
                                string concertName = concerts.Find(c => c.Id == ticket.ConcertId)?.Name ?? "Desconocido";
                                string clientName = clients.Find(c => c.Id == ticket.ClientId)?.Name ?? "Desconocido";

                                Console.WriteLine($"ID Tiquete: {ticket.Id} | Concierto: {concertName} | Cliente: {clientName} | Fecha Compra: {ticket.PurchaseDate}");
                            }
                        }
                        break;

                    case "3":
                        // EDITAR COMPRA
                        //Por ahora solo se va a modificar el cliente asociado al tiquete
                        Console.WriteLine("----Editar Compra de Tiquete----");
                        if (tickets.Count == 0)
                        {
                            Console.WriteLine("No hay tiquetes para editar.");
                            break;
                        }

                        Console.Write("Ingrese el ID del tiquete a editar: ");
                        int ticketIdToEdit = Convert.ToInt32(Console.ReadLine());

                        Ticket ticketToEdit = tickets.Find(t => t.Id == ticketIdToEdit);

                        if (ticketToEdit == null)
                        {
                            Console.WriteLine("Error: No se encontró un tiquete con ese ID.");
                        }
                        else
                        {
                            Console.Write("Ingrese el nuevo ID del cliente para este tiquete: ");
                            int newClientId = Convert.ToInt32(Console.ReadLine());

                            // Validamos que el nuevo cliente exista
                            Client newClient = clients.Find(c => c.Id == newClientId);
                            if (newClient == null)
                            {
                                Console.WriteLine("Error: El nuevo ID de cliente no existe.");
                            }
                            else
                            {
                                ticketToEdit.ClientId = newClientId;
                                Console.WriteLine("¡Tiquete actualizado con éxito!");
                            }
                        }
                        break;

                    case "Eliminar compra":
                        // ELIMINAR COMPRA
                        Console.WriteLine("--- Eliminar Compra de Tiquete ---");
                        if (tickets.Count == 0)
                        {
                            Console.WriteLine("No hay tiquetes para eliminar.");
                            break;
                        }

                        Console.Write("Ingrese el ID del tiquete que desea eliminar: ");
                        int ticketIdToDelete = Convert.ToInt32(Console.ReadLine());

                        Ticket ticketToDelete = tickets.Find(t => t.Id == ticketIdToDelete);
                        
                        if (ticketToDelete == null)
                        {
                            Console.WriteLine("Error: No se encontró un tiquete con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine($"Tiquete a eliminar: ID {ticketToDelete.Id}");
                            Console.Write("¿Está seguro? (S/N): ");
                            string confirmation = Console.ReadLine();
                            if (confirmation.ToUpper() == "S")
                            {
                                tickets.Remove(ticketToDelete);
                                Console.WriteLine("Compra eliminada con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                        }
                        break;

                    case "5":
                        exitModule = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (!exitModule)
                {
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
        
        public void ShowPurchaseHistory()
        {
            Console.Clear();
            Console.WriteLine("===== Historial de Compras por Cliente =====");

            // Validar que existan clientes para poder buscar
            if (clients.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados para mostrar su historial.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Pedir la cédula del cliente a consultar
            Console.Write("Ingrese la Cédula del cliente para ver su historial: ");
            string cedulaToSearch = Console.ReadLine();

            // Buscar al cliente por su cédula
            Client selectedClient = null;
            foreach (var client in clients)
            {
                if (client.Cedula == cedulaToSearch)
                {
                    selectedClient = client;
                    break;
                }
            }

            // Validar si el cliente fue encontrado
            if (selectedClient == null)
            {
                Console.WriteLine("Error: No se encontró un cliente con esa cédula.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            // Buscar todos los tiquetes que le pertenecen a ese cliente
            List<Ticket> clientTickets = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                if (ticket.ClientId == selectedClient.Id)
                {
                    clientTickets.Add(ticket);
                }
            }

            // Mostrar el reporte
            Console.WriteLine($"--- Historial de Compras de: {selectedClient.Name} ---");

            if (clientTickets.Count == 0)
            {
                Console.WriteLine("Este cliente no ha realizado ninguna compra.");
            }
            else
            {
                foreach (var ticket in clientTickets)
                {
                    // Para cada tiquete, buscamos el nombre del concierto correspondiente
                    string concertName = "Concierto no encontrado"; 
                    foreach (var concert in concerts)
                    {
                        if (concert.Id == ticket.ConcertId)
                        {
                            concertName = concert.Name;
                            break;
                        }
                    }
                    Console.WriteLine($"- Tiquete ID: {ticket.Id} | Concierto: {concertName} | Fecha de Compra: {ticket.PurchaseDate.ToShortDateString()}");
                }
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
        public void RunAdvancedQueries()
        {
            bool exitModule = false;
            while (!exitModule)
            {
                Console.Clear();
                Console.WriteLine("===== Consultas Avanzadas (LINQ) =====");
                Console.WriteLine("1. Consultar conciertos por ciudad");
                Console.WriteLine("2. Consultar conciertos por rango de fechas");
                Console.WriteLine("3. Consultar cliente con más compras");
                Console.WriteLine("4. Consultar concierto con más tiquetes vendidos");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        // --- CONSULTAR CONCIERTOS POR CIUDAD ---
                        Console.Write("Ingrese la ciudad a buscar: ");
                        string cityToSearch = Console.ReadLine();

                        var concertsInCity = concerts.Where(c => c.City.ToLower() == cityToSearch.ToLower()).ToList();

                        Console.WriteLine($"--- Conciertos en: {cityToSearch} ---");
                        if (concertsInCity.Count == 0)
                        {
                            Console.WriteLine("No se encontraron conciertos en esa ciudad.");
                        }
                        else
                        {
                            foreach (var concert in concertsInCity)
                            {
                                concert.ShowInfo();
                            }
                        }
                        break;

                    case "2":
                        // --- CONSULTAR CONCIERTOS POR RANGO DE FECHAS ---
                        try
                        {
                            Console.Write("Ingrese la fecha de inicio (formato AÑO-MES-DÍA): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());
                            
                            Console.Write("Ingrese la fecha de fin (formato AÑO-MES-DÍA): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());

                            var concertsInDateRange = concerts.Where(c => c.Date >= startDate && c.Date <= endDate).ToList();

                            Console.WriteLine($"--- Conciertos entre {startDate.ToShortDateString()} y {endDate.ToShortDateString()} ---");
                            if (concertsInDateRange.Count == 0)
                            {
                                Console.WriteLine("No se encontraron conciertos en ese rango de fechas.");
                            }
                            else
                            {
                                foreach (var concert in concertsInDateRange)
                                {
                                    concert.ShowInfo();
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: Formato de fecha no válido.");
                        }
                        break;

                    case "3":
                        // --- CONSULTAR CLIENTE CON MÁS COMPRAS ---
                        Console.WriteLine("--- Cliente con Más Compras ---");
                        if (tickets.Count == 0)
                        {
                            Console.WriteLine("Aún no se han realizado compras.");
                            break;
                        }

                        var clientGroup = tickets
                            .GroupBy(ticket => ticket.ClientId)
                            .OrderByDescending(group => group.Count())
                            .FirstOrDefault();

                        Client topClient = clients.Find(c => c.Id == clientGroup.Key);

                        Console.WriteLine($"El cliente con más compras es: {topClient.Name} con {clientGroup.Count()} tiquetes comprados.");
                        break;
                        
                    case "4":
                        // --- CONSULTAR CONCIERTO CON MÁS TIQUETES VENDIDOS ---
                        Console.WriteLine("--- Concierto Más Popular ---");
                        if (tickets.Count == 0)
                        {
                            Console.WriteLine("Aún no se han vendido tiquetes.");
                            break;
                        }
                        
                        var concertGroup = tickets
                            .GroupBy(ticket => ticket.ConcertId)
                            .OrderByDescending(group => group.Count())
                            .FirstOrDefault();
                        
                        Concert topConcert = concerts.Find(c => c.Id == concertGroup.Key);
                        
                        Console.WriteLine($"El concierto con más tiquetes vendidos es: '{topConcert.Name}' con {concertGroup.Count()} tiquetes.");
                        break;

                    case "5":
                        exitModule = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (!exitModule)
                {
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}