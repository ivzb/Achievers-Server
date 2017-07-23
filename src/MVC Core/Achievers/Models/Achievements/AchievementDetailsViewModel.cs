using Achievers.Data.Models;
using Achievers.Infrastructure.Mapping;
using Achievers.Models.Evidence;
using AutoMapper;
using System.Collections.Generic;

namespace Achievers.Models.Achievements
{
    public class AchievementDetailsViewModel : IMapFrom<Achievement>, IMapTo<Achievement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Involvement { get; set; }

        /// <summary>
        /// Evidence that this Achievement contains
        /// </summary>
        public List<EvidenceViewModel> Evidence { get; set; }

        //public string AuthorId { get; set; }

        //public ProfileViewModel Author { get; set; }

        public int CategoryId { get;set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AchievementDetailsViewModel, Achievement>()
                .ForMember(x => x.Id, m => m.Ignore());
        }

        //public static Expression<Func<Achievement, AchievementDetailsViewModel>> FromAchievement
        //    => x => new AchievementDetailsViewModel
        //    {
        //        Id = x.Id,
        //        Title = x.Title,
        //        Description = x.Description,
        //        ImageUrl = x.ImageUrl,
        //        Involvement = EnumExtensions<Involvement>.GetDisplayValue(x.Involvement),
        //        Evidence = x.Evidence.AsQueryable<Achievers.Data.Models.Evidence>().Select(EvidenceViewModel.FromEvidence).ToList()
        //    };
    }
}