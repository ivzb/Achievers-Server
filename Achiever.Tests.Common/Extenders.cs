using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Achiever.Common;
using Achiever.Common.Extenders;

namespace Achiever.Tests.Common
{
    [TestClass]
    public class Extenders
    {
        [TestMethod]
        public void DateTimeExtender_StartOfWeek()
        {
            DateTime date = new DateTime(2016, 10, 18);
            DateTime startOfWeek = date.StartOfWeek(DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2016, 10, 12), startOfWeek);
        }

        [TestMethod]
        public void DateTimeExtender_EndOfWeek()
        {
            DateTime date = new DateTime(2016, 10, 14, 10, 22, 4);
            DateTime endOfWeek = date.EndOfWeek(DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2016, 10, 18, 23, 59, 59, 999), endOfWeek);
        }
    }
}
