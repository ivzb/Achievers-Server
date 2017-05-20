namespace Achiever.Services.Data.Interfaces
{
    using Achiever.Data;
    using Achiever.Services.Models;
    using System.Linq;

    public interface IEvidenceService : IDefaultService<Evidence>
    {
        IQueryable<Evidence> GetByAchievementId(int evidenceId, IServicePage servicePage);
    }
}