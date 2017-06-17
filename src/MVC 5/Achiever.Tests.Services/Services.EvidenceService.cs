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
    public class EvidenceServiceTest : BaseServicesTest
    {
        private IEvidenceService evidenceService;

        public EvidenceServiceTest()
            : base()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IDbRepository<Evidence>> evidenceRepoMock = new Mock<IDbRepository<Evidence>>();

            evidenceRepoMock
                .Setup(r => r.All())
                .Returns(base.Evidence.AsQueryable());

            evidenceRepoMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns<int>((id) => this.Evidence.First(x => x.Id == id));

            this.evidenceService = new EvidenceService(evidenceRepoMock.Object);
        }

        [TestMethod]
        public void EvidenceService_Get()
        {
            foreach (Evidence mock in this.Evidence)
            {
                Evidence serviceResult = this.evidenceService.Get(mock.Id);
                Assert.IsTrue(mock.Equals(serviceResult));
            }
        }

        [TestMethod]
        public void EvidenceService_GetByCategoryId()
        {
            int pageSize = 21;
            int pageOffset = 1;

            ISet<int> achievementIds = new HashSet<int>(this.Achievements.Select(x => x.Id));

            foreach (int achievementId in achievementIds)
            {
                IEnumerable<Evidence> currentSelectedEvidence = base.Evidence
                    .Where(x => x.AchievementId == achievementId);

                int lastPage = currentSelectedEvidence.Count() / (pageSize - pageOffset);

                for (int pageIndex = 1; pageIndex <= lastPage + pageOffset; pageIndex++)
                {
                    IServicePage servicePage = new ServicePage(pageIndex, pageSize, pageOffset);

                    IList<Evidence> serviceResults = this.evidenceService
                        .Get()
                        .Where(x => x.AchievementId == achievementId)
                        .OrderByDescending(x => x.Id)
                        .Skip(servicePage.LinqSkip)
                        .Take(servicePage.LinqTake)
                        .ToList();

                    IList<Evidence> filteredMocks = currentSelectedEvidence
                        .OrderByDescending(x => x.Id)
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
        }
    }
}