namespace Achiever.Web.Service.Controllers
{
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;
    using Achiever.Web.Service.Controllers.Base;
    using Achiever.Web.ViewModels;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Query;
    using System.Web.OData.Routing;

    public class CategoriesController : GenericBaseController<Category, CategoryViewModel>
    {
        public CategoriesController(ICategoriesService service)
            : base(service)
        {
        }

        // GET: odata/Category(5)
        [EnableQuery]
        public Category GetCategory([FromODataUri] int key)
        {
            return base.service.Get(key);
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
            return base.service.Get();
        }

        // Parent
        // GET: odata/GetParentCategory
        [EnableQuery(
            PageSize = 21,
            AllowedArithmeticOperators = AllowedArithmeticOperators.None,
            AllowedFunctions = AllowedFunctions.None,
            AllowedLogicalOperators = AllowedLogicalOperators.None,
            AllowedOrderByProperties = "Id",
            AllowedQueryOptions = AllowedQueryOptions.Top |
                                         AllowedQueryOptions.Skip |
                                         AllowedQueryOptions.OrderBy)]
        [ODataRoute("GetParentCategory")]
        public IQueryable<Category> GetParentCategory()
        {
            return base.service.Get().Where(x => x.ParentId == null);
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
            return base.service.Get().Where(x => x.ParentId == key);
        }
    }
}