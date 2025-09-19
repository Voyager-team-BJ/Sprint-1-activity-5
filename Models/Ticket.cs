namespace riwiMusic.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set; }

        // --- AÑADE ESTE CONSTRUCTOR ---
        public Ticket(int id, int concertId, int clientId)
        {
            Id = id;
            ConcertId = concertId;
            ClientId = clientId;
            PurchaseDate = DateTime.Now; // La fecha se asigna automáticamente al crear
        }
    }
}