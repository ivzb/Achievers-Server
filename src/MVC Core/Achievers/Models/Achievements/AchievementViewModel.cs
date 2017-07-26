using Achievers.Data.Models;
using Achievers.Infrastructure.Mapping;
using AutoMapper;

namespace Achievers.Models.Achievements
{
    public class AchievementViewModel : IMapFrom<Achievement>, IMapTo<Achievement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Involvement { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AchievementViewModel, Achievement>()
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}