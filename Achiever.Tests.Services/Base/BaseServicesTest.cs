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

            this.InitCategories();
            this.InitAchievements();

            //this.MapAchievementsAndThropheys();
            //this.MapAchievementsAndGroups();
        }

        protected Random Random { get; private set; }
        protected IList<Achievement> Achievements { get; private set; }
        protected IList<Category> Categories { get; private set; }

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

        private void InitCategories()
        {
            this.Categories = new List<Category>();
            this.GenerateCategories(150);
        }
        private void GenerateCategories(int count)
        {
            if (count == 0) return;

            Category parent = GenerateCategory(null);

            for (int i = 0; i < 5; i++)
            {
                Category innerParent = GenerateCategory(parent);

                for (int j = 0; j < 3; j++) GenerateCategory(innerParent);
            }

            GenerateCategories(--count);
        }

        private Category GenerateCategory(Category parent)
        {
            int id = this.Categories.Count + 1;

            Category newCategory = new Category
            {
                Id = this.Categories.Count + 1,
                Title = this.RandomString(this.Random.Next(10, 30)),
                Description = this.RandomString(this.Random.Next(50, 100)),
                ImageUrl = this.RandomString(this.Random.Next(20, 30)),
                CreatedOn = DateTime.UtcNow
            };

            if (parent != null)
            {
                newCategory.ParentId = parent.Id;
                newCategory.Parent = parent;
            }

            this.Categories.Add(newCategory);
            return newCategory;
        }

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
                    CreatedOn = DateTime.UtcNow
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