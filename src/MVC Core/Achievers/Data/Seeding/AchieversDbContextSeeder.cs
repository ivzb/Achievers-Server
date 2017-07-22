using System;
using System.Linq;

using Achievers.Common;
using Achievers.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Achievers.Data.Seeding
{
    public static class AchieversDbContextSeeder
    {
        public static void Seed(AchieversDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            Seed(dbContext, roleManager);
        }



        // todo: extract in different classes

        public static void Seed(AchieversDbContext dbContext, RoleManager<Role> roleManager)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            SeedRoles(roleManager);
            SeedCategories(dbContext);
        }

        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            SeedRole(GlobalConstants.AdministratorRoleName, roleManager);
        }

        private static void SeedRole(string roleName, RoleManager<Role> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
            if (role == null)
            {
                var result = roleManager.CreateAsync(new Role(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static void SeedCategories(AchieversDbContext dbContext)
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

                GenerateAchievements(dbContext, child.Id, i * 3);

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

        private static void GenerateAchievements(AchieversDbContext dbContext, Category category, int count) {
            if (dbContext.Achievements.Count() > 0) return;

            for (int i = 0; i < count; i++) {
                GenerateAchievement(dbContext, category);
            }
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
