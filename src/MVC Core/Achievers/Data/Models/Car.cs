using Achievers.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Achievers.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.CarPropertyMinLength)]
        [MaxLength(Constants.CarPropertyMaxLength)]
        public string Make { get; set; }

        [Required]
        [MinLength(Constants.CarPropertyMinLength)]
        [MaxLength(Constants.CarPropertyMaxLength)]
        public string Model { get; set; }

        [Range(Constants.CarMinYear, Constants.CarMaxYear)]
        public int Year { get; set; }

        [Required]
        public string Image { get; set; }

        [Range(0, int.MaxValue)]
        public decimal PricePerDay { get; set; }

        public List<Renting> Rentings { get; set; }
    }
}
