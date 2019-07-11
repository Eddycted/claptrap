using CL4PTR4P.Data.Models.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public ICollection<PlayerTeam> PlayerTeams { get; set; } = new List<PlayerTeam>();
        public ICollection<TeamMatch> TeamMatches { get; set; } = new List<TeamMatch>();
        public ICollection<TeamTournament> TeamTournaments { get; set; } = new List<TeamTournament>();
    }
}