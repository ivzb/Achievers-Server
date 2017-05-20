namespace Achiever.Tests.Web.ViewModels
{
    using Achiever.Web.ViewModels.Abstract;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DurationDisplayableTests
    {
        [TestMethod]
        public void DurationDisplayableViewModel_CorrectFormat()
        {
            // Arrange
            DurationDisplayableViewModel hoursOnly = new DurationDisplayableTestChild() { Minutes = null,  Hours = 14 };
            DurationDisplayableViewModel minutesOnly = new DurationDisplayableTestChild() { Minutes = 22, Hours = null };
            DurationDisplayableViewModel combine = new DurationDisplayableTestChild() { Minutes = 22, Hours = 2 };

            // Act
            // Assert
            Assert.AreEqual("14h", hoursOnly.DurationAsString);
            Assert.AreEqual("22min", minutesOnly.DurationAsString);
            Assert.AreEqual("2h 22min", combine.DurationAsString);
        }

        [TestMethod]
        public void DurationDisplayableViewModel_Calculation()
        {
            // Arrange
            DurationDisplayableViewModel duration = new DurationDisplayableTestChild() { Hours = 1 };
            duration.Minutes = 61;

            // Act
            // Assert
            Assert.AreEqual(2, duration.Hours);
            Assert.AreEqual(1, duration.Minutes);
        }

        class DurationDisplayableTestChild : DurationDisplayableViewModel
        {
        }
    }
}