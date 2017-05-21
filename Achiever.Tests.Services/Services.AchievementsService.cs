namespace Achiever.Tests.Services
{
    using Achiever.Data;
    using Achiever.Data.Common;
    using Achiever.Services.Data;
    using Achiever.Services.Data.Interfaces;
    using Achiever.Services.Models;
    using Achiever.Tests.Web.ViewModels;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class AchievementsServiceTest : BaseServicesTest
    {
        private IAchievementsService achievementsService;

        public AchievementsServiceTest()
            : base()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IDbRepository<Achievement>> achievementRepoMock = new Mock<IDbRepository<Achievement>>();

            achievementRepoMock
                .Setup(r => r.All())
                .Returns(base.Achievements.AsQueryable());

            achievementRepoMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns<int>((id) => this.Achievements.First(x => x.Id == id));

            this.achievementsService = new AchievementsService(achievementRepoMock.Object);
        }

        [TestMethod]
        public void AchievementsService_Get()
        {
            foreach (Achievement mock in this.Achievements)
            {
                Achievement serviceResult = this.achievementsService.Get(mock.Id);
                Assert.IsTrue(mock.Equals(serviceResult));
            }
        }

        [TestMethod]
        public void AchievementsService_GetByCategoryId()
        {
            int pageSize = 21;
            int pageOffset = 1;

            ISet<int> categoryIds = new HashSet<int>(this.Categories.Where(x => x.Children.Count == 0).Select(x => x.Id));

            foreach (int categoryId in categoryIds)
            {
                IEnumerable<Achievement> currentSelectedAchievements = base.Achievements
                    .Where(x => x.CategoryId == categoryId);

                int lastPage = currentSelectedAchievements.Count() / (pageSize - pageOffset);

                for (int pageIndex = 1; pageIndex <= lastPage + pageOffset; pageIndex++)
                {
                    IServicePage servicePage = new ServicePage(pageIndex, pageSize, pageOffset);

                    IList<Achievement> serviceResults = this.achievementsService
                        .GetByCategoryId(categoryId, servicePage)
                        .ToList();

                    IList<Achievement> filteredMocks = currentSelectedAchievements
                        .OrderByDescending(x => x.CreatedOn)
                        .ThenByDescending(x => x.Id)
                        .Skip(servicePage.LinqSkip)
                        .Take(servicePage.LinqTake)
                        .ToList();

                    Assert.AreEqual(filteredMocks.Count, serviceResults.Count());

                    for (int i = 0; i < filteredMocks.Count; i++)
                    {
                        Assert.IsTrue(filteredMocks[i].Equals(serviceResults[i]));
                    }
                }
            }

            //[TestMethod]
            //public void AchievementsService_GetByThropheyId_RandomPage()
            //{
            //    int pageSize = 21;
            //    int pageOffset = 1;
            //    Throphey randomThrophey = base.Thropheys[base.Random.Next(0, base.Thropheys.Count)];

            //    IEnumerable<Achievement> allAchievements = base.Achievements
            //            .Where(x => x.ThropheyId == randomThrophey.Id);
            //    int lastPage = allAchievements.Count() / (pageSize - pageOffset);
            //    int randomPage = base.Random.Next(1, lastPage + 1);
            //    IServicePage randomServicePage = new ServicePage(randomPage, pageSize, pageOffset);

            //    IList<Achievement> serviceAchievements = this.achievementsService
            //        .GetByThropheyId(randomThrophey.Id, randomServicePage)
            //        .ToList();

            //    IList<Achievement> filteredAchievements = allAchievements
            //        .OrderByDescending(x => x.CreatedOn)
            //        .ThenByDescending(x => x.Id)
            //        .Skip(randomServicePage.LinqSkip)
            //        .Take(randomServicePage.LinqTake)
            //        .ToList();

            //    Assert.AreEqual(filteredAchievements.Count, serviceAchievements.Count());

            //    for (int i = 0; i < filteredAchievements.Count; i++)
            //    {
            //        Assert.IsTrue(filteredAchievements[i].Equals(serviceAchievements[i]));
            //    }
            //}
            //[TestMethod]
            //public void AchievementsService_GetByThropheyId_AllPossiblePages()
            //{
            //    int pageSize = 21;
            //    int pageOffset = 1;

            //    foreach (Throphey throphey in base.Thropheys)
            //    {
            //        IEnumerable<Achievement> allAchievements = base.Achievements
            //            .Where(x => x.ThropheyId == throphey.Id);

            //        int lastPage = allAchievements.Count() / (pageSize - pageOffset);

            //        for (int pageIndex = 1; pageIndex <= lastPage + pageOffset; pageIndex++)
            //        {
            //            IServicePage servicePage = new ServicePage(pageIndex, pageSize, pageOffset);

            //            IList<Achievement> serviceAchievements = this.achievementsService
            //                .GetByThropheyId(throphey.Id, servicePage)
            //                .ToList();

            //            IList<Achievement> filteredAchievements = allAchievements
            //                .OrderByDescending(x => x.CreatedOn)
            //                .ThenByDescending(x => x.Id)
            //                .Skip(servicePage.LinqSkip)
            //                .Take(servicePage.LinqTake)
            //                .ToList();

            //            Assert.AreEqual(filteredAchievements.Count, serviceAchievements.Count());

            //            for (int i = 0; i < filteredAchievements.Count; i++)
            //            {
            //                Assert.IsTrue(filteredAchievements[i].Equals(serviceAchievements[i]));
            //            }
            //        }
            //    }
            //}
            //[TestMethod]
            //public void AchievementsService_GetByGroupId_RandomPage()
            //{
            //    int pageSize = 21;
            //    int pageOffset = 1;
            //    Group randomGroup = base.Groups[base.Random.Next(0, base.Groups.Count)];

            //    IEnumerable<Achievement> allAchievements = base.Achievements
            //            .Where(x => x.GroupId == randomGroup.Id);
            //    int lastPage = allAchievements.Count() / (pageSize - pageOffset);
            //    int randomPage = base.Random.Next(1, lastPage + 1);
            //    IServicePage randomServicePage = new ServicePage(randomPage, pageSize, pageOffset);

            //    IList<Achievement> serviceAchievements = this.achievementsService
            //        .GetByGroupId(randomGroup.Id, randomServicePage)
            //        .ToList();

            //    IList<Achievement> filteredAchievements = allAchievements
            //        .OrderByDescending(x => x.CreatedOn)
            //        .ThenByDescending(x => x.Id)
            //        .Skip(randomServicePage.LinqSkip)
            //        .Take(randomServicePage.LinqTake)
            //        .ToList();

            //    Assert.AreEqual(filteredAchievements.Count, serviceAchievements.Count());

            //    for (int i = 0; i < filteredAchievements.Count; i++)
            //    {
            //        Assert.IsTrue(filteredAchievements[i].Equals(serviceAchievements[i]));
            //    }
            //}
            //[TestMethod]
            //public void AchievementsService_GetByGroupId_AllPossiblePages()
            //{
            //    int pageSize = 21;
            //    int pageOffset = 1;

            //    foreach (Group group in base.Groups)
            //    {
            //        IEnumerable<Achievement> allAchievements = base.Achievements
            //            .Where(x => x.GroupId == group.Id);
            //        int lastPage = allAchievements.Count() / (pageSize - pageOffset);

            //        for (int pageIndex = 1; pageIndex <= lastPage + pageOffset; pageIndex++)
            //        {
            //            IServicePage servicePage = new ServicePage(pageIndex, pageSize, pageOffset);

            //            IList<Achievement> serviceAchievements = this.achievementsService
            //                .GetByGroupId(group.Id, servicePage)
            //                .ToList();

            //            IList<Achievement> filteredAchievements = allAchievements
            //                .OrderByDescending(x => x.CreatedOn)
            //                .ThenByDescending(x => x.Id)
            //                .Skip(servicePage.LinqSkip)
            //                .Take(servicePage.LinqTake)
            //                .ToList();

            //            Assert.AreEqual(filteredAchievements.Count, serviceAchievements.Count());

            //            for (int i = 0; i < filteredAchievements.Count; i++)
            //            {
            //                Assert.IsTrue(filteredAchievements[i].Equals(serviceAchievements[i]));
            //            }
            //        }
            //    }
            //}
            //[TestMethod]
            //public void AchievementsService_Search()
            //{
            //    int pageSize = 21;
            //    int pageOffset = 1;

            //    for (int searches = 0; searches < 10; searches++)
            //    {
            //        string randomWord = string.Empty;

            //        while (randomWord == string.Empty || randomWord.Length < 3)
            //        {
            //            Achievement randomAchievement = base.Achievements[base.Random.Next(0, base.Achievements.Count)];

            //            if (searches % 2 == 0)
            //            {
            //                string[] splitTitle = randomAchievement.Title.Split(' ');
            //                randomWord = splitTitle[base.Random.Next(0, splitTitle.Length - 1)];
            //            }
            //            else
            //            {
            //                string[] splitDescription = randomAchievement.Description.Split(' ');
            //                randomWord = splitDescription[base.Random.Next(0, splitDescription.Length - 1)];
            //            }
            //        }

            //        IEnumerable<Achievement> searchAchievements = base.Achievements
            //            .Where(x => x.Title.Contains(randomWord) || x.Description.Contains(randomWord));

            //        int lastPage = searchAchievements.Count() / (pageSize - pageOffset);

            //        for (int pageIndex = 1; pageIndex <= lastPage + pageOffset; pageIndex++)
            //        {
            //            IServicePage servicePage = new ServicePage(pageIndex, pageSize, pageOffset);

            //            IList<Achievement> serviceAchievements = this.achievementsService
            //                .Search(randomWord, servicePage)
            //                .ToList();

            //            IList<Achievement> filteredAchievements = searchAchievements
            //                .OrderByDescending(x => x.CreatedOn)
            //                .ThenByDescending(x => x.Id)
            //                .Skip(servicePage.LinqSkip)
            //                .Take(servicePage.LinqTake)
            //                .ToList();

            //            Assert.AreEqual(filteredAchievements.Count, serviceAchievements.Count());

            //            for (int i = 0; i < filteredAchievements.Count; i++)
            //            {
            //                Assert.IsTrue(filteredAchievements[i].Equals(serviceAchievements[i]));
            //            }
            //        }
            //    }
            //} 
        }
    }
}