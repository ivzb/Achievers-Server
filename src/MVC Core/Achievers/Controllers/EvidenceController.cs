using Achievers.Infrastructure.Extensions;
using Achievers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Achievers.Controllers
{
    //[Authorize]
    public class EvidenceController : Controller
    {
        private readonly IEvidenceService evidence;
        private readonly IAchievementsService achievements;

        public EvidenceController(IEvidenceService evidence, IAchievementsService achievements)
        {
            this.evidence = evidence;
            this.achievements = achievements;
        }

        public async Task<IActionResult> Details(int id)
        {
            return await this.JsonOrNotFound(async () => await this.evidence.FindAsync(id));
        }

        public async Task<IActionResult> LoadByAchievement(int achievementId)
        {
            if (!(await this.achievements.ExistAsync(achievementId)))
            {
                return this.NotFound(achievementId);
            }

            return await this.JsonOrNotFound(async () => await this.evidence.LoadByAchievementAsync(achievementId));
        }
    }
}
