using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    /// <summary>
    /// 厂家访问服务类
    /// </summary>
    internal class VendorService : AbstractLocalService<Vendor, string>, IVendorService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private VendorBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 厂家访问服务类
        /// </summary>
        public VendorService() : base(BusinessFactory<VendorBusiness>.Instance)
        {
            this.bl = this.baseBL as VendorBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按名称查找厂商
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public Vendor FindByName(string name)
        {
            return this.bl.FindByName(name);
        }
        #endregion //Method
    }
}
