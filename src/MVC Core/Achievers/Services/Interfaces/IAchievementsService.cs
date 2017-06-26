using Achievers.Models.Achievements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Achievers.Services.Interfaces
{
    public interface IAchievementsService
    {
        Task<AchievementDetailsViewModel> FindAsync(int id);

        Task<List<AchievementViewModel>> LoadByCategoryAsync(int categoryId);

        Task<bool> ExistAsync(int id);
    }
}