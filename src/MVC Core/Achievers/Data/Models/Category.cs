using System.Collections.Generic;

namespace Achievers.Data.Models
{
    /// <summary>
    /// Categories are hierarchical (Agency list) and only leaf Categories might have Achievements
    /// </summary>
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        /// <summary>
        /// Achievements that this Category contains
        /// </summary>
        public List<Achievement> Achievements { get; set; }

        /// <summary>
        /// Children Categories
        /// </summary>
        public List<Category> Children { get; set; }
    }
}