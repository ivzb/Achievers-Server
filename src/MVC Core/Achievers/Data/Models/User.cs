using Achievers.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Achievers.Data.Models
{
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
