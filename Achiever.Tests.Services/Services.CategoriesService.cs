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
    }
}