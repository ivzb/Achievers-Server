using Achievers.Data.Models;
using Achievers.Infrastructure.Extensions;
using System;
using System.Linq.Expressions;

namespace Achievers.Models.Evidence
{
    public class EvidenceDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string EvidenceType { get; set; }

        public static Expression<Func<Achievers.Data.Models.Evidence, EvidenceDetailsViewModel>> FromEvidence
            => x => new EvidenceDetailsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url.
                EvidenceType = EnumExtensions<EvidenceType>.GetDisplayValue(x.EvidenceType)
            };
    }
}