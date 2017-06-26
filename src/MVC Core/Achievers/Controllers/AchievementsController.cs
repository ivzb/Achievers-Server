using Achievers.Infrastructure.Extensions;
using Achievers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Achievers.Controllers
{
    [Authorize]
    public class AchievementsController : Controller
    {
        private readonly IAchievementsService achievements;
        private readonly ICategoriesService categories;

        public AchievementsController(IAchievementsService achievements, ICategoriesService categories)
        {
            this.achievements = achievements;
            this.categories = categories;
        }

        public async Task<IActionResult> Details(int id)
        {
            return await this.JsonOrNotFound(async () => await this.achievements.FindAsync(id));
        }

        public async Task<IActionResult> LoadByCategory(int categoryId)
        {
            if (!(await this.categories.ExistAsync(categoryId)))
            {
                return this.NotFound(categoryId);
            }

            return await this.JsonOrNotFound(async () => await this.achievements.LoadByCategoryAsync(categoryId));
        }
    }
}