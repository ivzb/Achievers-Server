using System.Linq;
using Achiever.Data.Common.Models;

namespace Achiever.Data.Common
{
    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();
        T GetById(TKey id);
        void Add(T entity);
        void Update(T entity);
        void HardDelete(T entity);
        void Attach(T entity);
        void AttachModel<M>(M entity) where M : class;
        int Save();
    }
}
