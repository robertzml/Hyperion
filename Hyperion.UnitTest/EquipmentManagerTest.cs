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
    public class EquipmentManagerTest
    {
        public EquipmentManagerTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindBySerial()
        {
            string serialnumber = "23244387837482";

            var entity = BusinessFactory<EquipmentManagerBusiness>.Instance.FindBySerialNumber(serialnumber);

            Assert.AreEqual(serialnumber, entity.SerialNumber);
            Assert.IsNull(entity.UpdateDate);
        }
    }
}
