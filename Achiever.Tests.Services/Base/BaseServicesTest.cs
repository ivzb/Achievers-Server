namespace Achiever.Tests.Web.ViewModels
{
    using Achiever.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BaseServicesTest
    {
        public BaseServicesTest()
        {
            this.Random = new Random();

            this.InitAchievements();
            //this.InitThropheys();
            //this.InitGroups();

            //this.MapAchievementsAndThropheys();
            //this.MapAchievementsAndGroups();
        }

        protected Random Random {get; private set; }
        protected IList<Achievement> Achievements { get; private set; }
        //protected IList<Throphey> Thropheys { get; private set; }
        //protected IList<Group> Groups { get; private set; }

        protected string RandomString(int length = 4)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789             ";
            StringBuilder sb = new StringBuilder();

            string randomChars = new string(
                Enumerable.Repeat(chars, length)
                    .Select(x => x[this.Random.Next(x.Length)])
                    .ToArray()
            );

            return randomChars;
        }

        //private void InitThropheys()
        //{
        //    this.Thropheys = new List<Throphey>();

        //    foreach (ThropheyLevelEnum thropheyLevelEnum in Enum.GetValues(typeof(ThropheyLevelEnum)))
        //    {
        //        this.Thropheys.Add(new Throphey
        //        {
        //            Id = (int)thropheyLevelEnum,
        //            Name = thropheyLevelEnum.ToString(),
        //            Level = (int)thropheyLevelEnum,
        //            Achievements = new List<Achievement>(),
        //            CreatedOn = DateTime.Now
        //        });
        //    }
        //}
        //private void InitGroups()
        //{
        //    this.Groups = new List<Group>();

        //    for (int i = 1; i < 50; i++)
        //    {
        //        this.Groups.Add(new Group
        //        {
        //            Id = i,
        //            Title = this.RandomString(this.Random.Next(3, 6)),
        //            Description = this.RandomString(this.Random.Next(25, 50)),
        //            Image = this.RandomString(this.Random.Next(500, 1000)),
        //            Achievements = new List<Achievement>(),
        //            CreatedOn = DateTime.Now
        //        });
        //    }
        //}
        private void InitAchievements()
        {
            this.Achievements = new List<Achievement>();

            for (int i = 1; i < 1000; i++)
            {
                this.Achievements.Add(new Achievement
                {
                    Id = i,
                    Title = this.RandomString(this.Random.Next(10, 30)),
                    Description = this.RandomString(this.Random.Next(50, 100)),
                    CreatedOn = DateTime.Now
                });
            }
        }
        //private void MapAchievementsAndGroups()
        //{
        //    foreach (Achievement achievement in this.Achievements)
        //    {
        //        Group group = this.Groups[this.Random.Next(0, this.Groups.Count)];

        //        achievement.GroupId = group.Id;
        //        achievement.Group = group;

        //        group.Achievements.Add(achievement);
        //    }
        //}
        //private void MapAchievementsAndThropheys()
        //{
        //    foreach (Achievement achievement in this.Achievements)
        //    {
        //        Throphey throphey = this.Thropheys[this.Random.Next(0, this.Thropheys.Count)];

        //        achievement.ThropheyId = throphey.Id;
        //        achievement.Throphey = throphey;

        //        throphey.Achievements.Add(achievement);
        //    }
        //}
    }
}