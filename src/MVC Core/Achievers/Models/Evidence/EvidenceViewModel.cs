using Achievers.Data.Models;
using Achievers.Infrastructure.Extensions;
using Achievers.Infrastructure.Mapping;
using Achievers.Models.Achievements;
using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Achievers.Models.Evidence
{
    public class EvidenceViewModel : IMapFrom<Achievers.Data.Models.Evidence>, IMapTo<Achievers.Data.Models.Evidence>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string EvidenceType { get; set; }

        public string Url { get; set; }

        public int AchievementId { get; set; }

        public AchievementViewModel Achievement { get; set; }

        //public string AuthorId { get; set; }

        //public User Author { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EvidenceViewModel, Achievers.Data.Models.Evidence>()
                .ForMember(x => x.Id, m => m.Ignore());
        }

        //public static Expression<Func<Achievers.Data.Models.Evidence, EvidenceViewModel>> FromEvidence
        //    => x => new EvidenceViewModel
        //    {
        //        Id = x.Id,
        //        Title = x.Title,
        //        Url = x.Url,
        //        EvidenceType = EnumExtensions<EvidenceType>.GetDisplayValue(x.EvidenceType)
        //    };
    }
}