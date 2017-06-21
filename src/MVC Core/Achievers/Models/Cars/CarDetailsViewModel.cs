using Achievers.Data.Models;
using System;
using System.Linq.Expressions;

namespace Achievers.Models.Cars
{
    public class CarDetailsViewModel
    {
        public static Expression<Func<Car, CarDetailsViewModel>> FromCar
            => c => new CarDetailsViewModel
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                PricePerDay = c.PricePerDay,
                Year = c.Year,
                Image = c.Image
            };

        public int Id { get; set; }
        
        public string Make { get; set; }
        
        public string Model { get; set; }
        
        public int Year { get; set; }
        
        public string Image { get; set; }
        
        public decimal PricePerDay { get; set; }
    }
}
