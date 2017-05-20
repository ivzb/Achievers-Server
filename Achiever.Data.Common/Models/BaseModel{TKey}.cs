using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Achiever.Data.Common.Models
{
    public abstract class BaseModel<TKey> : IAuditInfo //, IDeletableEntity
    {
        [Key]
        public new TKey Id { get; set; }

        public new DateTime CreatedOn { get; set; }
    }
}