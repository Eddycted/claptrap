using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public List<Player> Players { get; set; }
        public List<Team> Teams { get; set; }
    }
}