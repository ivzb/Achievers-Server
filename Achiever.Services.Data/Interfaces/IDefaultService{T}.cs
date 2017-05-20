using Achiever.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achiever.Services.Data.Interfaces
{
    public interface IDefaultService<T> : IBaseService<T, int>
        where T : BaseModel<int>
    {
    }
}