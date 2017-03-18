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
    public class EquipmentTest
    {
        public EquipmentTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindOne()
        {
            int userid = 219;
            string serialNumber = "12345671234567";

            var entity = BusinessFactory<EquipmentBusiness>.Instance.FindOne(userid, serialNumber);

            Assert.AreEqual(serialNumber, entity.SerialNumber);
            Assert.AreEqual("1234567", entity.Name);
        }

        [TestMethod]
        public void TestFindBySerial()
        {
            string serialNumber = "16080533001009";

            var data = BusinessFactory<EquipmentBusiness>.Instance.FindBySerialNumber(serialNumber);

            foreach (var item in data)
            {
                Assert.AreEqual(serialNumber, item.SerialNumber);
            }

            Assert.AreEqual(8, data.Count());
        }

        [TestMethod]
        public void TestFindByUser()
        {
            int userId = 850;

            var data = BusinessFactory<EquipmentBusiness>.Instance.FindByUserId(userId);

            foreach (var item in data)
            {
                Assert.AreEqual(1, item.HomeId);
            }
        }
    }
}
