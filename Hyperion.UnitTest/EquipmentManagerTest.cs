using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    [TestClass]
    public class EquipmentManagerTest
    {
        public EquipmentManagerTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindBySerial()
        {
            string serialnumber = "11223344556677";

            var entity = BusinessFactory<EquipmentManagerBusiness>.Instance.FindBySerialNumber(serialnumber);

            Assert.AreEqual(serialnumber, entity.SerialNumber);
            Assert.IsNull(entity.CreateDate);
        }

        [TestMethod]
        public void TestFindAll()
        {
            var data = CallerFactory<IEquipmentManagerService>.Instance.FindAll().ToList();

            Assert.AreEqual(135, data.Count);
        }
    }
}
