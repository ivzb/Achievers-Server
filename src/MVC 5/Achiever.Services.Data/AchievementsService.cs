namespace Achiever.Services.Data
{
    using Achiever.Data.Common;
    using Achiever.Data.Models;
    using Achiever.Services.Data.Interfaces;

    public class AchievementsService : DefaultService<Achievement>, IAchievementsService
    {
        public AchievementsService(IDbRepository<Achievement> achievementsRepository)
            : base(achievementsRepository)
        {
        }

        //public IQueryable<Achievement> Search(string search, IServicePage servicePage)
        //{
        //   // List<int> ids = new List<int>();

        //   //ids.AddRange(t1.Result) 

        //   // //string[] descriptions = this.Get().Select(x => x.Description).ToArray(); 
        //   // //Parallel.For(0, descriptions.Length,
        //   // //    () => 0,
        //   // //    (x, loopState, subtotal) =>
        //   // //    {
        //   // //        StringBuilder sb = new StringBuilder(descriptions[x]);
        //   // //        sb.Replace(search, string.Empty);

        //   // //        if (descriptions[x].Length - sb.Length > 0)
        //   // //        {
        //   // //            lock (lockObject)
        //   // //            {
        //   // //                ids.Add(x + 1);
        //   // //            }
        //   // //        }

        //   // //        return 0; // not used
        //   // //    },
        //   // //    (s) => { } // not used
        //   // //);

        //   // //ids = ids.Distinct().ToList();

        //    // TODO: OPTIMIZE THIS QUERY !!!
        //    IQueryable<Achievement> achievements = this.Get()
        //        .Where(x => x.Title.Contains(search) || x.Description.Contains(search))
        //        //.Where(x => ids.Contains(x.Id))
        //        .OrderByDescending(x => x.CreatedOn)
        //        .ThenByDescending(x => x.Id)
        //        .Skip(() => servicePage.LinqSkip)
        //        .Take(() => servicePage.LinqTake);

        //    return achievements;
        //}
    }
}