namespace Achiever.Services.Data
{
    using Achiever.Data.Common;
    using Achiever.Data.Common.Models;
    using Achiever.Services.Data.Interfaces;
    using Achiever.Services.Models;
    using System.Linq;

    public class DefaultService<T> : BaseService<T, int>, IDefaultService<T>
        where T : BaseModel<int>
    {
        public DefaultService(IDbRepository<T> repo)
            : base(repo)
        {
        }

        protected IQueryable<T> Get(IServicePage servicePage)
        {
            IQueryable<T> entities = this.Get(servicePage);
            return entities;
        }
    }
}