﻿namespace Achiever.Data.Models
{
    using Achiever.Data.Common.Models;
    using System;
    using System.Collections.Generic;

    public class Achievement : BaseModel<int>
    {
        private ICollection<Evidence> evidence;

        public Achievement()
        {
            this.evidence = new HashSet<Evidence>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Involvement Involvement { get; set; }

        /// <summary>
        /// Evidence that this Achievement contains
        /// </summary>
        public virtual ICollection<Evidence> Evidence
        {
            get { return this.evidence; }

            set { this.evidence = value; }
        }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}