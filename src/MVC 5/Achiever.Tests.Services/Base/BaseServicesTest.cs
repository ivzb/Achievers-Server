namespace Achiever.Tests.Web.ViewModels
{
    using Achiever.Data;
    using Achiever.Services.Data.Interfaces;
    using Common.Extenders;
    using Data.Common.Models;
    using Data.Models;
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
            this.MapAchievementsToCategories();

            this.InitEvidence();
            this.MapEvidenceToAchievements();
        }

        protected Random Random { get; private set; }
        protected IList<Achievement> Achievements { get; private set; }
        protected IList<Category> Categories { get; private set; }
        protected IList<Evidence> Evidence { get; private set; }

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
            this.GenerateCategories(15);
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

            for (int i = 1; i < 10000; i++)
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
        private void MapAchievementsToCategories()
        {
            Category[] leafCategories = this.Categories.Where(x => x.Children.Count == 0).Distinct().ToArray();

            foreach (Achievement achievement in this.Achievements)
            {
                Category category = leafCategories[this.Random.Next(0, leafCategories.Length)];

                achievement.CategoryId = category.Id;
                achievement.Category = category;

                category.Achievements.Add(achievement);
            }
        }

        private void InitEvidence()
        {
            this.Evidence = new List<Evidence>();

            for (int i = 1; i < 20000; i++)
            {
                this.Evidence.Add(new Evidence 
                {
                    Id = i,
                    Title = this.RandomString(this.Random.Next(10, 30)),
                    Url = this.RandomString(this.Random.Next(50, 100)),
                    EvidenceType = EnumExtenders.RandomEnumValue<EvidenceType>(),
                    CreatedOn = DateTime.UtcNow
                });
            }
        }
        private void MapEvidenceToAchievements()
        {
            foreach (Evidence evidence in this.Evidence)
            {
                Achievement achievement = this.Achievements[this.Random.Next(0, this.Achievements.Count)];

                evidence.AchievementId = achievement.Id;
                evidence.Achievement = achievement;

                achievement.Evidence.Add(evidence);
            }
        }
    }
}