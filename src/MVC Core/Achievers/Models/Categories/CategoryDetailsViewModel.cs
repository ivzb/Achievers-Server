using Achievers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Achievers.Models.Categories
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? ParentId { get; set; }

        public List<AchievementViewModel> Achievements { get; set; }

        public static Expression<Func<Category, CategoryDetailsViewModel>> FromCategory
            => x => new CategoryDetailsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                ParentId = x.ParentId,
                Achievements = x.Achievements.Select(AchievementViewModel.FromAchievement)
            };
    }
}