namespace Achiever.Services.Data.Interfaces
{
    using Achiever.Data.Common.Models;
    using Achiever.Services.Models;
    using System.Linq;

    public interface IDefaultService<T> : IBaseService<T, int>
        where T : BaseModel<int>
    {
    }
}