using Achievers.Models;
using System.ComponentModel.DataAnnotations;

namespace Achievers.Data.Models
{
    public class Renting
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public int Days { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
