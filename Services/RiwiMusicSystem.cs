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