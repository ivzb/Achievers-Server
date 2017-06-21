using Achievers.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Achievers.Models.Cars
{
    public class CreateCarViewModel
    {
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
        
        [Display(Name = "Price per day")]
        [Range(0, int.MaxValue)]
        public decimal PricePerDay { get; set; }
    }
}
