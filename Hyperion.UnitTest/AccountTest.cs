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
    public class AccountTest
    {
        public AccountTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindOne()
        {
            int id = 466;
            var account = BusinessFactory<AccountBusiness>.Instance.FindById(id);

            Assert.AreEqual(1, account.LoginState);
        }

        [TestMethod]
        public void TestNullField()
        {
            int id = 463;
            var account = BusinessFactory<AccountBusiness>.Instance.FindById(id);

            Assert.IsNull(account.UpdateDate);
        }

        [TestMethod]
        public void TestCount()
        {
            var data = BusinessFactory<AccountBusiness>.Instance.FindAll();
            Assert.AreEqual(200, data.ToList().Count);
        }
    }
}
