namespace CL4PTR4P.Data.Models.JoinEntities
{
    public class PlayerMatch
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}