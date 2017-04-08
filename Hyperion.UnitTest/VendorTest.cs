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
    public class VendorTest
    {
        public VendorTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindByName()
        {
            var info = BusinessFactory<VendorInfoBusiness>.Instance.FindByName("AUPU");

            Assert.AreEqual("AUPU", info.Name);
        }

        [TestMethod]
        public void TestEdit()
        {
            int id = 18;
            var info = BusinessFactory<VendorInfoBusiness>.Instance.FindById(id);

            info.Description = "remark";

            BusinessFactory<VendorInfoBusiness>.Instance.Update(info);

            var info2 = BusinessFactory<VendorInfoBusiness>.Instance.FindById(id);

            Assert.AreEqual("remark", info2.Description);
        }
    }
}
