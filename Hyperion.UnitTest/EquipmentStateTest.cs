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

    public class EquipmentStateTest
    {
        public EquipmentStateTest()
        {
            GlobalAction.Initialize();
        }

        [Fact]
        public void TestCreate()
        {
            EquipmentState entity = new EquipmentState();
            entity.SerialNumber = "ad34dss";
            entity.LogTime = DateTime.Now;
            entity.SwitchState = "1";
            entity.HeatingTime = "234";
            entity.HotWater = "44";
            
            var result = BusinessFactory<EquipmentStateBusiness>.Instance.Create(entity);
          
            Assert.Equal(entity.SerialNumber, result.SerialNumber);
        }
    }
}
