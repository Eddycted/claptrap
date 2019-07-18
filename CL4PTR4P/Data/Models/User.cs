using CL4PTR4P.Data.Models.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public ulong UserId { get; set; }
        public string Name { get; set; }

        public ICollection<GameUser> GameUsers { get; set; } = new List<GameUser>();
    }
}