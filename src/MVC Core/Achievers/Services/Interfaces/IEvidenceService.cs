using Achievers.Models.Evidence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Achievers.Services.Interfaces
{
    public interface IEvidenceService
    {
        Task<EvidenceDetailsViewModel> FindAsync(int id);

        Task<List<EvidenceViewModel>> LoadByAchievementAsync(int achievementId);

        Task<bool> ExistAsync(int id);
    }
}
