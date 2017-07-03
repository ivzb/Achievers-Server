using Achievers.Common.Models;
using System.Collections.Generic;

namespace Achievers.Data.Models
{
    public class Achievement : BaseModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Involvement Involvement { get; set; }

        /// <summary>
        /// Evidence that this Achievement contains
        /// </summary>
        public List<Evidence> Evidence { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
