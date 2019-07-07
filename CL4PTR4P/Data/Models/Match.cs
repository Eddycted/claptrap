using CL4PTR4P.Data.Models.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public Tournament Tournament { get; set; }
        public ICollection<PlayerMatch> PlayerMatches { get; set; }
        public ICollection<TeamMatch> TeamMatches { get; set; }
    }
}