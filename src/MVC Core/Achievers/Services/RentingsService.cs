using Achievers.Data;
using Achievers.Data.Models;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public class RentingsService : IRentingsService
    {
        private readonly CarRentingDbContext data;

        public RentingsService(CarRentingDbContext data)
        {
            this.data = data;
        }

        public async Task Rent(int carId, string userId, int days, decimal carPricePerDay)
        {
            var renting = new Renting
            {
                CarId = carId,
                UserId = userId,
                Days = days,
                TotalPrice = carPricePerDay * days
            };

            this.data.Add(renting);

            await this.data.SaveChangesAsync();
        }
    }
}
