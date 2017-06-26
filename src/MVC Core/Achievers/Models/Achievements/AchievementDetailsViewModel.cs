using Achievers.Data.Models;
using Achievers.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Achievers.Models.Achievements
{
    public class AchievementDetailsViewModel
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

        public static Expression<Func<Achievement, AchievementDetailsViewModel>> FromAchievement
            => x => new AchievementDetailsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Involvement = EnumExtensions<Involvement>.GetDisplayValue(x.Involvement),
                Evidence = x.Evidence.Select(EvidenceViewModel.FromEvidence)
            };
    }
}