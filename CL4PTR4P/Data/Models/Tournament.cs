using CL4PTR4P.Data.Enums;
using CL4PTR4P.Data.Models.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TournamentFormat Format { get; set; }
        public int TeamSize { get; set; }
        public DateTime StartTime { get; set; }

        public ICollection<PlayerTournament> PlayerTournaments { get; set; } = new List<PlayerTournament>();
        public ICollection<Match> Matches { get; set; }
        public ICollection<TeamTournament> TeamTournaments { get; set; }
    }
}