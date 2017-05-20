namespace Achiever.Tests.Data
{
    using Achiever.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AchievementModelTest
    {
        [TestMethod]
        public void CreateAchievement()
        {
            Achievement achievement = new Achievement
            {
                Id = 5,
                Title = "title",
                Description = "description",
                
            };

            Assert.AreEqual(5, achievement.Id);
            Assert.AreEqual("title", achievement.Title);
            Assert.AreEqual("description", achievement.Description); 
        }
    }
}