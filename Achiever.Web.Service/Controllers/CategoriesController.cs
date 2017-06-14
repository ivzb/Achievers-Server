namespace Achiever.Web.Service.Controllers
{
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;
    using Achiever.Web.Service.Controllers.Base;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Query;
    using System.Web.OData.Routing;

    //[Authorize]
    public class CategoriesController : BaseController
    {
        IDefaultService<Category> service;

        public CategoriesController(IDefaultService<Category> service)
        {
            this.service = service;
        }

        // GET: odata/Categories(5)
        [EnableQuery]
        public Category GetCategory([FromODataUri] int? key)
        {
            return this.service.Get(key.Value);
        }

        // GET: odata/Categories
        [EnableQuery(
            PageSize = 21,
            AllowedArithmeticOperators = AllowedArithmeticOperators.None,
            AllowedFunctions           = AllowedFunctions.None,
            AllowedLogicalOperators    = AllowedLogicalOperators.None,
            AllowedOrderByProperties   = "Id",
            AllowedQueryOptions        = AllowedQueryOptions.Top |
                                         AllowedQueryOptions.Skip |
                                         AllowedQueryOptions.OrderBy)]
        public IQueryable<Category> GetCategories()
        {
            return this.service.Get();
        }

        // Parent
        // GET: odata/GetRootCategoryChildren
        [EnableQuery(
            PageSize = 21,
            AllowedArithmeticOperators = AllowedArithmeticOperators.None,
            AllowedFunctions = AllowedFunctions.None,
            AllowedLogicalOperators = AllowedLogicalOperators.None,
            AllowedOrderByProperties = "Id",
            AllowedQueryOptions = AllowedQueryOptions.Top |
                                         AllowedQueryOptions.Skip |
                                         AllowedQueryOptions.OrderBy)]
        [ODataRoute("RootCategoryChildren")]
        public IQueryable<Category> GetRootCategoryChildren()
        {
            return this.service.Get().Where(x => x.ParentId == null);
        }

        // GET: odata/Categories(5)/Children
        [EnableQuery(
            PageSize = 21,
            AllowedArithmeticOperators = AllowedArithmeticOperators.None,
            AllowedFunctions = AllowedFunctions.None,
            AllowedLogicalOperators = AllowedLogicalOperators.None,
            AllowedOrderByProperties = "Id",
            AllowedQueryOptions = AllowedQueryOptions.Top |
                                         AllowedQueryOptions.Skip |
                                         AllowedQueryOptions.OrderBy)]
        public IQueryable<Category> GetChildren([FromODataUri] int key)
        {
            return this.service.Get().Where(x => x.ParentId == key);
        }

        // GET: odata/Categories(5)/Achievements
        [EnableQuery(
            PageSize = 21,
            AllowedArithmeticOperators = AllowedArithmeticOperators.None,
            AllowedFunctions = AllowedFunctions.None,
            AllowedLogicalOperators = AllowedLogicalOperators.None,
            AllowedOrderByProperties = "Id",
            AllowedQueryOptions = AllowedQueryOptions.Top |
                                         AllowedQueryOptions.Skip |
                                         AllowedQueryOptions.OrderBy)]
        public IQueryable<Achievement> GetAchievements([FromODataUri] int key)
        {
            return this.service.Get().Where(m => m.Id == key).SelectMany(m => m.Achievements);
        }
    }
}