using Achievers.Data.Models;
using System;
using System.Linq.Expressions;

namespace Achievers.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> FromCategory
            => x => new CategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ImageUrl = x.ImageUrl
            };
    }
}
