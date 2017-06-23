using Achievers.Data;
using Achievers.Data.Models;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public class RentingsService : IRentingsService
    {
        private readonly AchieversDbContext data;

        public RentingsService(AchieversDbContext data)
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
