using CL4PTR4P.Data.Models.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public ulong PlayerId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public ICollection<PlayerTournament> PlayerTournaments { get; set; } 
    }
}