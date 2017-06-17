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
        protected IList<ApplicationUser> ApplicationUsers { get; private set; }

        protected override void Seed(Achiever.Data.ApplicationDbContext context)
        {
            if (context.Categories.Count() == 0)
            {
                this.Context = context;
                this.Random = new Random();

                this.ApplicationUsers = this.Context.Users.ToList();
                this.InitCategories();
                this.InitAchievements();
                this.Achievements = this.Context.Achievements.ToList();
                this.InitEvidence();
            }
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

                //for (int j = 0; j < 3; j++) GenerateCategory(innerParent);
            }

            GenerateCategories(--count);
        }

        private Category GenerateCategory(Category parent)
        {
            Category newCategory = new Category
            {
                Title = Faker.Lorem.GetFirstWord(),
                Description = Faker.Lorem.Sentence(5),
                ImageUrl = "https://unsplash.it/500/500/?random&a=" + this.Random.Next(0, 100),
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

            for (int i = 1; i < 500; i++)
            {
                Achievement newAchievement = new Achievement
                {
                    Title = Faker.Lorem.GetFirstWord(),
                    Description = Faker.Lorem.Sentence(5),
                    CategoryId = leafCategories[this.Random.Next(0, leafCategories.Length)].Id,
                    ImageUrl = "https://unsplash.it/500/500/?random&a=" + this.Random.Next(0, 100),
                    Involvement = (Involvement) this.Random.Next(1, 6),
                    CreatedOn = DateTime.UtcNow,
                    AuthorId = this.ApplicationUsers[this.Random.Next(0, this.ApplicationUsers.Count)].Id
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

            for (int i = 1; i < 10000; i++)
            {
                Evidence newEvidence = new Evidence
                {
                    Title = Faker.Lorem.GetFirstWord(),
                    EvidenceType = EnumExtenders.RandomEnumValue<EvidenceType>(),
                    AchievementId = achievements[this.Random.Next(0, achievements.Length)].Id,
                    CreatedOn = DateTime.UtcNow,
                    AuthorId = this.ApplicationUsers[this.Random.Next(0, this.ApplicationUsers.Count)].Id
                };

                if (newEvidence.EvidenceType == EvidenceType.Image)
                {
                    newEvidence.Url = "https://unsplash.it/500/500/?random&a=" + this.Random.Next(0, 100);
                }
                else if (newEvidence.EvidenceType == EvidenceType.Video)
                {
                    newEvidence.Url = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
                }

                this.Context.Evidecne.Add(newEvidence);
                this.Evidence.Add(newEvidence);
            }

            this.Context.SaveChanges();
        }
    }
}