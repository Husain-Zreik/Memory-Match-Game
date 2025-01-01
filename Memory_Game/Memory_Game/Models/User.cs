namespace Memory_Game.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Age { get; set; } 
    }
}
