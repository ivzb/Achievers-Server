using Achievers.Data;
using Achievers.Infrastructure.Mapping;
using Achievers.Models.Achievements;
using Achievers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public class AchievementsService : BaseService, IAchievementsService
    {
        public AchievementsService(AchieversDbContext data)
            : base(data)
        {
        }

        public async Task<AchievementDetailsViewModel> FindAsync(int id)
        {
            return await this.Data
                .Achievements
                .Where(x => x.Id == id)
                .To<AchievementDetailsViewModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<List<AchievementViewModel>> LoadByCategoryAsync(int categoryId)
        {
            return await this.Data
                .Achievements
                .Where(x => x.CategoryId == categoryId)
                .To<AchievementViewModel>()
                .ToListAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.Data
                .Achievements
                .AnyAsync(x => x.Id == id);
        }
    }
}
