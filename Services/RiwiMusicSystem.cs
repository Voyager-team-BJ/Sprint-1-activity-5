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
            Console.WriteLine("Módulo de Conciertos - Lógica a implementar por Persona 2.");
            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
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
                        
                        Client newClient = new Client();
                        newClient.Id = nextClientId;
                        newClient.Cedula = clientCedula;
                        newClient.Name = clientName;
                        newClient.Email = clientEmail;
                        
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