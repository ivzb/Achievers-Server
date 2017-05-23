namespace Achiever.Services.Data
{
    using Achiever.Data;
    using Achiever.Data.Common;
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;
    using Achiever.Services.Models;
    using System.Data.Entity;
    using System.Linq;

    public class CategoriesService : DefaultService<Category>, ICategoriesService
    {
        public CategoriesService(IDbRepository<Category> categoriesRepository)
            : base(categoriesRepository)
        {
        }
    }
}