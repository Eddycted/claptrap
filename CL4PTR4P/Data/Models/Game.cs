using CL4PTR4P.Data.Models.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameUser> GameUsers { get; set; } = new List<GameUser>();
    }
}