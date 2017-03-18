using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    [TestClass]
    public class HomeTest
    {
        public HomeTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindOne()
        {
            int userid = 8;
            int homeid = 1;

            var entity = BusinessFactory<HomeBusiness>.Instance.FindOne(userid, homeid);

            Assert.AreEqual(userid, entity.UserId);
            Assert.AreEqual(homeid, entity.HomeId);

            Console.WriteLine(entity.Name);
        }
    }
}
