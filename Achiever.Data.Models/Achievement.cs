namespace Achiever.Data.Models
{
    using Achiever.Data.Common.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public Category Category { get; set; }

        public Involvement Involvement { get; set; }

        /// <summary>
        /// Evidence that this Achievement contains
        /// </summary>
        public virtual ICollection<Evidence> Evidence
        {
            get { return this.evidence; }

            set { this.evidence = value; }
        }
    }
}