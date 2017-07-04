using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Achievers.Data
{
    public class AchieversDbContext : IdentityDbContext<User, Role, string>
    {
        public AchieversDbContext(DbContextOptions<AchieversDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<Evidence> Evidence { get; set; }
    }
}