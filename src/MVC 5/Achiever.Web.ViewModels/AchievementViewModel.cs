namespace Achiever.Web.ViewModels
{
    using Achiever.Data;
    using Achiever.Web.Infrastructure.Mapping;
    using Achiever.Web.ViewModels.Abstract;
    using AutoMapper;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AchievementViewModel : BaseViewModel, IMapFrom<Achievement>, IMapTo<Achievement>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<AchievementViewModel, Achievement>()
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}