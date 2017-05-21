﻿namespace Achiever.Services.Data.Interfaces
{
    using Achiever.Data;
    using Achiever.Data.Models;
    using Achiever.Services.Models;
    using System.Linq;

    public interface IAchievementsService : IDefaultService<Achievement>
    {
        IQueryable<Achievement> GetByCategoryId(int? categoryId, IServicePage servicePage);
    }
}
