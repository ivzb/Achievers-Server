namespace Achiever.Data.Migrations
{
    using Achiever.Common.Extenders;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Achiever.Data.ApplicationDbContext>
    {
        public Configuration()
        {
#if DEBUG
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
#endif
        }

        protected ApplicationDbContext Context { get; private set; }
        protected Random Random { get; private set; }

        protected IList<Achievement> Achievements { get; private set; }
        protected IList<Category> Categories { get; private set; }
        protected IList<Evidence> Evidence { get; private set; }

        protected override void Seed(Achiever.Data.ApplicationDbContext context)
        {
            if (context.Categories.Count() == 0)
            {
                this.Context = context;
                this.Random = new Random();

                this.InitCategories();
                this.InitAchievements();
                this.InitEvidence();
            }
        }

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
            this.GenerateCategories(5);
        }
        private void GenerateCategories(int count)
        {
            if (count == 0) return;

            Category parent = GenerateCategory(null);

            for (int i = 0; i < 3; i++)
            {
                Category innerParent = GenerateCategory(parent);

                for (int j = 0; j < 3; j++) GenerateCategory(innerParent);
            }

            GenerateCategories(--count);
        }

        private Category GenerateCategory(Category parent)
        {
            Category newCategory = new Category
            {
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

            this.Context.Categories.Add(newCategory);
            this.Context.SaveChanges();
            this.Categories.Add(newCategory);

            return newCategory;
        }

        private void InitAchievements()
        {
            this.Achievements = new List<Achievement>();
            Category[] leafCategories = this.Categories.Where(x => x.Children.Count == 0).Distinct().ToArray();

            for (int i = 1; i < 100; i++)
            {
                Achievement newAchievement = new Achievement
                {
                    Title = this.RandomString(this.Random.Next(10, 30)),
                    Description = this.RandomString(this.Random.Next(50, 100)),
                    CategoryId = leafCategories[this.Random.Next(0, leafCategories.Length)].Id,
                    CreatedOn = DateTime.UtcNow,
                };

                this.Context.Achievements.Add(newAchievement);
                this.Achievements.Add(newAchievement);
            }

            this.Context.SaveChanges();
        }

        private void InitEvidence()
        {
            this.Evidence = new List<Evidence>();
            Achievement[] achievements = this.Achievements.Distinct().ToArray();

            for (int i = 1; i < 500; i++)
            {
                Evidence newEvidence = new Evidence
                {
                    Title = this.RandomString(this.Random.Next(10, 30)),
                    Url = this.RandomString(this.Random.Next(50, 100)),
                    EvidenceType = EnumExtenders.RandomEnumValue<EvidenceType>(),
                    AchievementId = achievements[this.Random.Next(0, achievements.Length)].Id,
                    CreatedOn = DateTime.UtcNow
                };

                this.Context.Evidecne.Add(newEvidence);
                this.Evidence.Add(newEvidence);
            }

            this.Context.SaveChanges();
        }
    }
}
