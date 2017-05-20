using System;
using System.Collections.Generic;
using System.Linq;

namespace Achiever.Data.Common
{
    public class BaseReportData<T> : IReportData<T>
        where T : class
    {
        private ICollection<T> data;

        public IEnumerable<T> Data { get { return this.data; } set { this.data = value.ToList(); } }

        public BaseReportData()
        {
            this.data = new List<T>();
        }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException("Value cannot be null");
            }

            this.data.Add(value);
        }
    }
}
