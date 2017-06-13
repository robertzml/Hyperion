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

    public class EquipmentAlarmTest
    {
        public EquipmentAlarmTest()
        {
            GlobalAction.Initialize();
        }

        [Fact]
        public void TestCreate()
        {
            EquipmentAlarm entity = new EquipmentAlarm();
            entity.SerialNumber = "ad34dss";
            entity.AlarmCode = "03";
            entity.LogTime = DateTime.Now;

            var result = BusinessFactory<EquipmentAlarmBusiness>.Instance.Create(entity);


            Assert.Equal(entity.SerialNumber, result.SerialNumber);
        }
    }
}
