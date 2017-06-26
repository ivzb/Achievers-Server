using Achievers.Data.Models;
using Achievers.Infrastructure.Extensions;
using System;
using System.Linq.Expressions;

namespace Achievers.Models.Achievements
{
    public class AchievementViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Involvement { get; set; }

        public static Expression<Func<Achievement, AchievementViewModel>> FromAchievement
            => x => new AchievementViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Involvement = EnumExtensions<Involvement>.GetDisplayValue(x.Involvement),
            };
    }
}