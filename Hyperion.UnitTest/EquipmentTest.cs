using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.UnitTest
{
    using Xunit;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    public class EquipmentTest
    {
        public EquipmentTest()
        {
            GlobalAction.Initialize();
        }

        [Fact]
        public void TestCreate()
        {
            Equipment entity = new Equipment();
            entity.SerialNumber = "qwerty";
            entity.Vendor = "Mulan";
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = entity.CreateTime;
            entity.Online = 1;
            entity.Status = 0;

            var result = BusinessFactory<EquipmentBusiness>.Instance.Create(entity);


            Assert.Equal(entity.SerialNumber, result.SerialNumber);
        }

        [Fact]
        public void TestFind()
        {
            var data = BusinessFactory<EquipmentBusiness>.Instance.FindAll();

            Assert.Equal(1, data.Count());
        }
    }
}
