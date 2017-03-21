using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    [TestClass]
    public class AlarmReportTest
    {
        public AlarmReportTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindByUser()
        {
            int userid = 23;

            var data = BusinessFactory<AlarmReportBusiness>.Instance.FindByUser(userid).ToList();

            Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            var count = BusinessFactory<AlarmReportBusiness>.Instance.Count();

            Assert.AreEqual(56, count);
        }

        [TestMethod]
        public void TestFindWithPage()
        {
            var data = BusinessFactory<AlarmReportBusiness>.Instance.FindWithPage(10, 20).ToList();
            Assert.AreEqual(20, data.Count);
        }
    }
}
