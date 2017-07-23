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

            RoleManager<Role> roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            Seed(dbContext, roleManager);
        }

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

            RolesSeed.SeedRoles(roleManager);
            CategoriesSeed.SeedCategories(dbContext);
        }
    }
}
