namespace CL4PTR4P.Data.Models.JoinEntities
{
    public class PlayerTeam
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}