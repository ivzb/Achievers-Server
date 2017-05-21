namespace Achiever.Services.Data.Interfaces
{
    using Achiever.Data;
    using Achiever.Data.Models;
    using Achiever.Services.Models;
    using System.Linq;

    public interface ICategoriesService : IDefaultService<Category>
    {
        IQueryable<Category> GetByParentId(int? parentId, IServicePage servicePage);
    }
}
