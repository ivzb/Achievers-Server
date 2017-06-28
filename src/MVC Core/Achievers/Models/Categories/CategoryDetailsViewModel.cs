using Achievers.Data.Models;
using Achievers.Infrastructure.Mapping;
using Achievers.Models.Achievements;
using AutoMapper;
using System.Collections.Generic;

namespace Achievers.Models.Categories
{
    public class CategoryDetailsViewModel : IMapFrom<Category>, IMapTo<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? ParentId { get; set; }

        public List<AchievementViewModel> Achievements { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CategoryDetailsViewModel, Category>()
                .ForMember(x => x.Id, m => m.Ignore());
        }

        //public static Expression<Func<Category, CategoryDetailsViewModel>> FromCategory
        //    => x => new CategoryDetailsViewModel
        //    {
        //        Id = x.Id,
        //        Title = x.Title,
        //        Description = x.Description,
        //        ImageUrl = x.ImageUrl,
        //        ParentId = x.ParentId,
        //        Achievements = x.Achievements.Select(AchievementViewModel.FromAchievement).ToList()
        //    };
    }
}