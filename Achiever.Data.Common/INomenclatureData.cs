using Achiever.Data.Common.Models;

namespace Achiever.Data.Common
{
    public interface INomenclatureData
    {
        int SaveChanges();
        IDbRepository<T> GetRepository<T>()
            where T : BaseModel<int>;
    }
}
