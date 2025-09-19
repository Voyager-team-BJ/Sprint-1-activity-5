namespace riwiMusic.Models
{
    public class Client
    {
        public int Id { get; set; }
        
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id} | Cédula: {Cedula} | Nombre: {Name} | Email: {Email}");
        }
    }
}