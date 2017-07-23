using System;
using System.Linq;
using Achievers.Common;
using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Achievers.Data.Seeding
{
    public static class CategoriesSeed
    {
        public static void SeedCategories(AchieversDbContext dbContext)
        {
            if (dbContext.Categories.Count() > 0) return;

            GenerateCategories(dbContext, 5);
        }

        private static void GenerateCategories(AchieversDbContext dbContext, int count)
        {
            if (count == 0) return;

            Category parent = GenerateCategory(dbContext, null);

            for (int i = 0; i < 3; i++)
            {
                Category child = GenerateCategory(dbContext, parent);

                AchievementsSeed.SeedAchievements(dbContext, child, Faker.RandomNumber.Next(5, 10));

                //for (int j = 0; j < 3; j++) GenerateCategory(child);
            }

            GenerateCategories(dbContext, --count);
        }

        private static Category GenerateCategory(AchieversDbContext dbContext, Category parent)
        {
            Category newCategory = new Category
            {
                Title = Faker.Lorem.GetFirstWord(),
                Description = Faker.Lorem.Sentence(5),
                ImageUrl = "https://unsplash.it/500/500/?random&a=" + Faker.RandomNumber.Next(0, 100),
                //CreatedOn = DateTime.UtcNow
            };

            if (parent != null)
            {
                newCategory.ParentId = parent.Id;
                newCategory.Parent = parent;
            }

            dbContext.Categories.Add(newCategory);
            dbContext.SaveChanges();

            return newCategory;
        }
    }
}