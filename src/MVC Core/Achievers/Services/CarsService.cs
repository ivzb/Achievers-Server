using Achievers.Data;
using Achievers.Data.Models;
using System.Threading.Tasks;
using Achievers.Models.Cars;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Achievers.Services
{
    public class CarsService : ICarsService
    {
        private readonly AchieversDbContext data;

        public CarsService(AchieversDbContext data)
        {
            this.data = data;
        }

        public async Task<List<CarDetailsViewModel>> AllAsync(int page, int pageSize, string search = null)
        {
            var query = this.data.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query
                    .Where(c => c.Model.Contains(search) || c.Make.Contains(search));
            }
            
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(CarDetailsViewModel.FromCar)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(
            string make,
            string model,
            int year,
            decimal pricePerDay,
            string imageId)
        {
            var newCar = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                PricePerDay = pricePerDay,
                Image = imageId
            };

            this.data.Add(newCar);
            await this.data.SaveChangesAsync();

            return newCar.Id;
        }

        public async Task<CarDetailsViewModel> FindAsync(int id)
            => await this.data
                .Cars
                .Where(c => c.Id == id)
                .Select(CarDetailsViewModel.FromCar)
                .FirstOrDefaultAsync();

        public async Task<decimal> GetCarPriceAsync(int id)
            => await this.data
                .Cars
                .Where(c => c.Id == id)
                .Select(c => c.PricePerDay)
                .FirstOrDefaultAsync();
    }
}
