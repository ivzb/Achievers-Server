using Achievers.Data.Models;
using Achievers.Infrastructure.Extensions;
using Achievers.Models.Achievements;
using System;
using System.Linq.Expressions;

namespace Achievers.Models.Evidence
{
    public class EvidenceViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string EvidenceType { get; set; }

        public string Url { get; set; }

        public int AchievementId { get; set; }

        public AchievementViewModel Achievement { get; set; }

        //public string AuthorId { get; set; }

        //public User Author { get; set; }

        public static Expression<Func<Achievers.Data.Models.Evidence, EvidenceViewModel>> FromEvidence
            => x => new EvidenceViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url,
                EvidenceType = EnumExtensions<EvidenceType>.GetDisplayValue(x.EvidenceType)
            };
    }
}