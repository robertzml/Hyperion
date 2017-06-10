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

    public class VendorTest
    {
        public VendorTest()
        {
            GlobalAction.Initialize();
        }

        [Fact]
        public void TestCreate()
        {
            Vendor vendor = new Vendor();
            vendor.Id = Guid.NewGuid().ToString();
            vendor.Name = "test name2";
            vendor.Code = "test code2";
            
            vendor.Status = 0;

            BusinessFactory<VendorBusiness>.Instance.Create(vendor, false);

            var info = BusinessFactory<VendorBusiness>.Instance.FindById(vendor.Id);

            Assert.Equal(vendor.Name, info.Name);
        }
    }
}
