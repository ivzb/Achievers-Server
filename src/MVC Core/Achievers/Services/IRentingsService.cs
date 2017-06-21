using System.Threading.Tasks;

namespace Achievers.Services
{
    public interface IRentingsService
    {
        Task Rent(int carId, string userId, int days, decimal carPricePerDay);
    }
}
