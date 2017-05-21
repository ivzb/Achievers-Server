using Achiever.Data.Common.Models;
using System.Collections.Generic;

namespace Achiever.Data.Models
{
    /// <summary>
    /// Categories are hierarchical (Agency list) and only leaf Categories might have Achievements
    /// </summary>
    public class Category : BaseModel<int>
    {
        private ICollection<Achievement> achievements;
        private ICollection<Category> children;

        public Category()
        {
            this.achievements = new HashSet<Achievement>();
            this.children = new HashSet<Category>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        /// <summary>
        /// Achievements that this Category contains
        /// </summary>
        public virtual ICollection<Achievement> Achievements
        {
            get { return this.achievements; }

            set { this.achievements = value; }
        }

        /// <summary>
        /// Children Categories
        /// </summary>
        public virtual ICollection<Category> Children
        {
            get { return this.children; }

            set { this.children = value; }
        }
    }
}