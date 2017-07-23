using System;
using System.Linq;
using Achievers.Common;
using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Achievers.Data.Seeding
{
    public static class AchievementsSeed
    {
        public static void SeedAchievements(AchieversDbContext dbContext, Category category, int count)
        {
            GenerateAchievements(dbContext, category, count);
        }

        private static void GenerateAchievements(AchieversDbContext dbContext, Category category, int count) {
            if (count == 0) return;

            GenerateAchievement(dbContext, category);

            GenerateAchievements(dbContext, category, --count);
        }

        private static Achievement GenerateAchievement(AchieversDbContext dbContext, Category category)
        {
            Achievement newAchievement = new Achievement
            {
                Title = Faker.Lorem.GetFirstWord(),
                Description = Faker.Lorem.Sentence(5),
                ImageUrl = "https://unsplash.it/500/500/?random&a=" + Faker.RandomNumber.Next(0, 100),
                Involvement = (Involvement) Faker.RandomNumber.Next(1, 5)
                //CreatedOn = DateTime.UtcNow
            };

            if (category != null)
            {
                newAchievement.CategoryId = category.Id;
                newAchievement.Category = category;
            }

            dbContext.Achievements.Add(newAchievement);
            dbContext.SaveChanges();

            return newAchievement;
        }
    }
}