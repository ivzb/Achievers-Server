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
    public class CategeoriesServiceTest : BaseServicesTest
    {
        private ICategoriesService categoriesService;

        public CategeoriesServiceTest()
            : base()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IDbRepository<Category>> categoryRepoMock = new Mock<IDbRepository<Category>>();

            categoryRepoMock
                .Setup(r => r.All())
                .Returns(base.Categories.AsQueryable());

            categoryRepoMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns<int>((id) => this.Categories.First(x => x.Id == id));

            this.categoriesService = new CategoriesService(categoryRepoMock.Object);
        }

        [TestMethod]
        public void CategoriesService_Get()
        {
            foreach (Category mock in this.Categories)
            {
                Category serviceResult = this.categoriesService.Get(mock.Id);
                Assert.IsTrue(mock.Equals(serviceResult));
            }
        }

        [TestMethod]
        public void CategoriesService_GetByParentId()
        {
            int pageSize = 21;
            int pageOffset = 1;

            ISet<int?> parentIds = new HashSet<int?>(this.Categories.Select(x => x.ParentId));

            foreach (int? parentId in parentIds)
            {
                IEnumerable<Category> currentSelectedCategories = base.Categories
                    .Where(x => x.ParentId == parentId);

                int lastPage = currentSelectedCategories.Count() / (pageSize - pageOffset);

                for (int pageIndex = 1; pageIndex <= lastPage + pageOffset; pageIndex++)
                {
                    IServicePage servicePage = new ServicePage(pageIndex, pageSize, pageOffset);

                    IList<Category> serviceResults = this.categoriesService
                        .GetByParentId(parentId, servicePage)
                        .ToList();

                    IList<Category> filteredMocks = currentSelectedCategories
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
        }
    }
}