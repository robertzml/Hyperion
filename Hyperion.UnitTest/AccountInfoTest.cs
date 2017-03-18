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
    public class AccountInfoTest
    {
        public AccountInfoTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindOne()
        {
            var info = BusinessFactory<AccountInfoBusiness>.Instance.FindById(350);

            Assert.AreEqual("AA", info.UserName);
            Assert.IsTrue(string.IsNullOrEmpty(info.Email));
        }
    }
}
