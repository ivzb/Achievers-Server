using Achievers.Models.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public interface ICarsService
    {
        Task<int> CreateAsync(string make, string model, int year, decimal pricePerDay, string imageId);

        Task<List<CarDetailsViewModel>> AllAsync(int page, int pageSize, string search = null); 

        Task<CarDetailsViewModel> FindAsync(int id);

        Task<decimal> GetCarPriceAsync(int id);
    }
}
