namespace CL4PTR4P.Data.Models.JoinEntities
{
    public class GameUser
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}