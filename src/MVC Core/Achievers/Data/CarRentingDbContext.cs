using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Achievers.Models;
using Achievers.Data.Models;

namespace Achievers.Data
{
    public class CarRentingDbContext : IdentityDbContext<User>
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Renting> Rentings { get; set; }
    }
}
