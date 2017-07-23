using System;
using System.Linq;
using Achievers.Common;
using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Achievers.Data.Seeding
{
    public static class RolesSeed
    {
        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            SeedRole(GlobalConstants.AdministratorRoleName, roleManager);
        }

        private static void SeedRole(string roleName, RoleManager<Role> roleManager)
        {
            Role role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();

            if (role == null)
            {
                IdentityResult result = roleManager.CreateAsync(new Role(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}