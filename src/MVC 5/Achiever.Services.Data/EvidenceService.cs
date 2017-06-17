namespace Achiever.Services.Data
{
    using Achiever.Data.Common;
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;

    public class EvidenceService : DefaultService<Evidence>, IEvidenceService
    {
        public EvidenceService(IDbRepository<Evidence> evidenceRepository)
            : base(evidenceRepository)
        {
        }
    }
}