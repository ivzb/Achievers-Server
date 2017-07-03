using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Common.Models
{
    public interface IPaging
    {
        int Page { get; }
        int Take { get; }
    }
}
