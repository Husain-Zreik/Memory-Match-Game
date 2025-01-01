namespace Memory_Game.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime RatedAt { get; set; }
    }
}
