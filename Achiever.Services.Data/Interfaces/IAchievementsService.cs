namespace Achiever.Services.Data.Interfaces
{
    using System;
    using System.Linq;
    using Achiever.Data;
    using Achiever.Services.Models;

    public interface IAchievementsService : IDefaultService<Achievement>
    {
        IQueryable<Achievement> Get(IServicePage servicePage);
        //IQueryable<Achievement> GetByThropheyId(int thropheyId, IServicePage servicePage);
        //IQueryable<Achievement> GetByGroupId(int groupId, IServicePage servicePage);
        IQueryable<Achievement> Search(string search, IServicePage servicePage);
    }
}
