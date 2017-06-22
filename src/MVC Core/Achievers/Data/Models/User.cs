using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace Achievers.Data.Models
{
    public class User : IdentityUser
    {
        public List<Renting> Rentings { get; set; }
    }
}
