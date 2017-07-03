using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Common.Models
{
    public class PagedEnumerable<T> : IPagedEnumerable<T>
    {
        private IEnumerable<T> collection;
        private int currentPage;
        private int pageSize;

        public PagedEnumerable(IEnumerable<T> collection, int totalCount)
        {
            this.collection = collection;
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
        }

        public long TotalCount { get; private set; }

        public int CurrentPage
        {
            get
            {
                if (this.currentPage > this.TotalPages)
                {
                    return this.TotalPages;
                }

                return this.currentPage;
            }
            set
            {
                if (value < 1)
                {
                    this.currentPage = 1;
                }
                else if (value > this.TotalPages)
                {
                    this.currentPage = this.TotalPages;
                }
                else
                {
                    this.currentPage = value;
                }
            }
        }

        public int PageSize
        {
            get
            {
                if (this.pageSize == 0)
                {
                    return this.collection.Count();
                }

                return this.pageSize;
            }
            set
            {
                this.pageSize = (value < 0) ? 0 : value;
            }
        }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(this.collection.Count() / (double)this.PageSize);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var pageSize = this.PageSize;
            var currentPage = this.CurrentPage;
            var startCount = (currentPage - 1) * pageSize;

            return this.collection.Skip(startCount).Take(pageSize).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}