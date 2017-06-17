namespace Achiever.Tests.Web.ViewModels
{
    using Achiever.Data;
    using Achiever.Web.ViewModels;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AchievementViewModelTest : BaseViewModelTest
    {
        public AchievementViewModelTest()
           : base()
        {
        }

        [TestMethod]
        public void AchievementViewModel_MapFrom()
        {
            Achievement model = new Achievement
            {
                Id = 5,
                Title = "Test title",
                Description = "Test description", 
            };

            AchievementViewModel viewModel = base.Mapper.Map<AchievementViewModel>(model);

            Assert.AreEqual(model.Id, viewModel.Id);
            Assert.AreEqual(model.Title, viewModel.Title);
            Assert.AreEqual(model.Description, viewModel.Description);
        }

        [TestMethod]
        public void AchievementViewModel_MapTo()
        {
            AchievementViewModel viewModel = new AchievementViewModel
            {
                Id = 5,
                Title = "Test title",
                Description = "Test description",
            };

            Achievement model = base.Mapper.Map<Achievement>(viewModel);

            Assert.AreEqual(0, model.Id);
            Assert.AreEqual(viewModel.Title, model.Title);
            Assert.AreEqual(viewModel.Description, model.Description);
        }
    }
}