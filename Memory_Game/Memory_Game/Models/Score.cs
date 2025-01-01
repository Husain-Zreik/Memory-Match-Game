namespace Memory_Game.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ScoreValue { get; set; }
        public int Level { get; set; }
        public DateTime AchievedAt { get; set; }
    }
}
