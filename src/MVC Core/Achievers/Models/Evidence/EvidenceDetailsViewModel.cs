using Achievers.Infrastructure.Mapping;
using AutoMapper;

namespace Achievers.Models.Evidence
{
    public class EvidenceDetailsViewModel : IMapFrom<Achievers.Data.Models.Evidence>, IMapTo<Achievers.Data.Models.Evidence>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string EvidenceType { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EvidenceDetailsViewModel, Achievers.Data.Models.Evidence>()
                .ForMember(x => x.Id, m => m.Ignore());
        }

        //public static Expression<Func<Achievers.Data.Models.Evidence, EvidenceDetailsViewModel>> FromEvidence
        //    => x => new EvidenceDetailsViewModel
        //    {
        //        Id = x.Id,
        //        Title = x.Title,
        //        Url = x.Url,
        //        EvidenceType = EnumExtensions<EvidenceType>.GetDisplayValue(x.EvidenceType)
        //    };
    }
}