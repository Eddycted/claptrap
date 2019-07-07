namespace CL4PTR4P.Data.Models.JoinEntities
{
    public class TeamMatch
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}