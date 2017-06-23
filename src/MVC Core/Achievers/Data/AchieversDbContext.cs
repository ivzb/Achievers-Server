using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Achievers.Data
{
    public class AchieversDbContext : IdentityDbContext<User>
    {
        public AchieversDbContext(DbContextOptions<AchieversDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Renting> Rentings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<Evidence> Evidence { get; set; }
    }
}