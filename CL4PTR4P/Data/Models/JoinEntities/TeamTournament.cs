namespace CL4PTR4P.Data.Models.JoinEntities
{
    public class TeamTournament
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}