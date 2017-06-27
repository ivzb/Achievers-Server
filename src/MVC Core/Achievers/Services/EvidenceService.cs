using Achievers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievers.Models.Evidence;
using Achievers.Data;
using Microsoft.EntityFrameworkCore;

namespace Achievers.Services
{
    public class EvidenceService : BaseService, IEvidenceService
    {
        public EvidenceService(AchieversDbContext data)
            : base(data)
        {
        }

        public async Task<EvidenceDetailsViewModel> FindAsync(int id)
        {
            return await this.Data
                .Evidence
                .Where(x => x.Id == id)
                .Select(EvidenceDetailsViewModel.FromEvidence)
                .FirstOrDefaultAsync();
        }

        public async Task<List<EvidenceViewModel>> LoadByAchievementAsync(int achievementId)
        {
            return await this.Data
                .Evidence
                .Where(x => x.AchievementId == achievementId)
                .Select(EvidenceViewModel.FromEvidence)
                .ToListAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.Data
                .Evidence
                .AnyAsync(x => x.Id == id);
        }
    }
}
