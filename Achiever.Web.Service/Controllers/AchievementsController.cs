namespace Achiever.Web.Service.Controllers
{
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;
    using System.Web.Http;
    using System.Web.Http.OData;
    using System.Linq;
    using Base;
    using System.Web.Http.OData.Query;

    public class AchievementsController : BaseController
    {
        private IDefaultService<Achievement> service;

        public AchievementsController(IDefaultService<Achievement> service)
        {
            this.service = service;
        }

        // GET: odata/Achievements(5)
        [EnableQuery]
        public Achievement GetAchievement([FromODataUri] int key)
        {
            return this.service.Get(key);
        }


        // GET: odata/Achievements(5)/Evidence
        [EnableQuery(
            PageSize = 21,
            AllowedArithmeticOperators = AllowedArithmeticOperators.None,
            AllowedFunctions = AllowedFunctions.None,
            AllowedLogicalOperators = AllowedLogicalOperators.None,
            AllowedOrderByProperties = "Id",
            AllowedQueryOptions = AllowedQueryOptions.Top |
                                         AllowedQueryOptions.Skip |
                                         AllowedQueryOptions.OrderBy)]
        public IQueryable<Evidence> GetEvidence([FromODataUri] int key)
        {
            return this.service.Get().Where(m => m.Id == key).SelectMany(m => m.Evidence);
        }
    }
}