using System.ComponentModel.DataAnnotations;

namespace CL4PTR4P.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}