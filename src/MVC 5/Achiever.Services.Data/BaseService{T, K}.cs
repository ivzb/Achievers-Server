﻿namespace Achiever.Services.Data
{
    using Achiever.Data.Common;
    using Achiever.Data.Common.Models;
    using Achiever.Services.Data.Interfaces;
    using System.Linq;

    /// <summary>
    /// Base service for CRUD operations
    /// </summary>
    /// <typeparam name="T">Type of the model, which the service operates</typeparam>
    /// <typeparam name="K">Key of the model, which the service operates</typeparam>
    public abstract class BaseService<T, K> : IBaseService<T, K>
        where T : BaseModel<K>
        where K : struct
    {
        protected IDbRepository<T, K> repository;

        public BaseService(IDbRepository<T, K> repo)
        {
            this.repository = repo;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>All entities as Queryable</returns>
        public virtual IQueryable<T> Get()
        {
            return this.repository.All();
        }
        public virtual T Get(K id)
        {
            return this.repository.GetById(id); 
        }
        public virtual void Add(T entity)
        {
            this.repository.Add(entity);
            this.repository.Save();
        }
        public virtual void Update(T entity)
        {
            this.repository.Update(entity);
            this.repository.Save();
        }
        public virtual void Delete(T entity)
        {
            this.repository.HardDelete(entity);
            this.repository.Save();
        }
    }
}