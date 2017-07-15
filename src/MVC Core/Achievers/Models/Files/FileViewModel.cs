using Achievers.Infrastructure.Mapping;
using AutoMapper;

namespace Achievers.Models.Files
{
    public class FileViewModel : IMapFrom<Achievers.Data.Models.File>, IMapTo<Achievers.Data.Models.File>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<FileViewModel, Achievers.Data.Models.File>()
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}