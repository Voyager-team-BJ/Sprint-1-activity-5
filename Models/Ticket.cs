using System;

namespace riwiMusic.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}