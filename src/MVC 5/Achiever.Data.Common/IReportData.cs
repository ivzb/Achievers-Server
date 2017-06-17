using System.Collections.Generic;

namespace Achiever.Data.Common
{
    public interface IReportData<T>
    {
        IEnumerable<T> Data { get; set; }
    }
}
