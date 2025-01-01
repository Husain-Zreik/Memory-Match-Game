namespace Memory_Game.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MaxLevels { get; set; }
        public int TimeLimitSeconds { get; set; }
        public string Difficulty { get; set; }
    }
}
