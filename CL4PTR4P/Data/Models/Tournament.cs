using CL4PTR4P.Data.Enums;
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
        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }
        public List<Team> Teams { get; set; }
        public int TeamSize { get; set; }
    }
}