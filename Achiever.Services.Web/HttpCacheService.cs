namespace Achiever.Services.Web
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Caching;

    public class HttpCacheService : ICacheService
    {
        private static readonly object LockObject = new object();

        public void Remove(string itemName)
        {
            HttpRuntime.Cache.Remove(itemName);
        }

        public T Get<T>(string itemName)
        {
            if (HttpRuntime.Cache[itemName] == null)
            {
                throw new KeyNotFoundException(string.Format("{0} not present", itemName));
            }

            return (T)HttpRuntime.Cache[itemName];
        }

        public void Set(string itemName, object data, int durationInSeconds)
        {
            lock (LockObject)
            {
                if (HttpRuntime.Cache[itemName] == null)
                {
                    // Add
                    Add(itemName, data, durationInSeconds);
                }
                else
                {
                    // Update
                    Remove(itemName);
                    Add(itemName, data, durationInSeconds);
                }
            }
        }

        private void Add(string itemName, object data, int durationInSeconds)
        {
            HttpRuntime.Cache.Insert(
                itemName,
                data,
                null,
                DateTime.UtcNow.AddSeconds(durationInSeconds),
                Cache.NoSlidingExpiration);
        }
    }
}
