namespace Achiever.Web.ViewModels
{
    using Achiever.Data;
    using Achiever.Web.Infrastructure.Mapping;
    using Achiever.Web.ViewModels.Abstract;
    using AutoMapper;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel : BaseViewModel, IMapFrom<Category>, IMapTo<Category>, IHaveCustomMappings
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<AchievementViewModel, Achievement>()
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}