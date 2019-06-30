using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}