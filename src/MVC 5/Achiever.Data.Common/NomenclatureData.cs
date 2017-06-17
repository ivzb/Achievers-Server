using Achiever.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Achiever.Data.Common
{
    public class NomenclatureData : INomenclatureData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public NomenclatureData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
        public IDbRepository<T> GetRepository<T>() where T : BaseModel<int>
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository =
                    Activator.CreateInstance(typeof(DbRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IDbRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
