using System.Collections.Generic;

namespace Achievers.Common.Models
{
    public interface IPagedEnumerable<out T> : IEnumerable<T>
    {
        long TotalCount { get; }
    }
}