namespace Achiever.Services.Data
{
    using Achiever.Data;
    using Achiever.Data.Common;
    using Achiever.Services.Data.Interfaces;
    using Achiever.Services.Models;
    using System.Data.Entity;
    using System.Linq;

    public class EvidenceService : DefaultService<Evidence>, IEvidenceService
    {
        public EvidenceService(IDbRepository<Evidence> evidenceRepository)
            : base(evidenceRepository)
        {
        }

        public IQueryable<Evidence> GetByAchievementId(int achievementId, IServicePage servicePage)
        {
            IQueryable<Evidence> entities = this.Get()
                .Where(x => x.AchievementId == achievementId)
                .OrderByDescending(x => x.Id)
                .Skip(() => servicePage.LinqSkip)
                .Take(() => servicePage.LinqTake);

            return entities;
        }
    }
}