namespace CL4PTR4P.Data.Models.JoinEntities
{
    public class PlayerTournament
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}