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
    internal class VendorInfoService : AbstractLocalService<VendorInfo, int>, IVendorInfoService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private VendorInfoBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 厂家访问服务类
        /// </summary>
        public VendorInfoService() : base(BusinessFactory<VendorInfoBusiness>.Instance)
        {
            this.bl = this.baseBL as VendorInfoBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按名称查找厂商
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public VendorInfo FindByName(string name)
        {
            return this.bl.FindByName(name);
        }
        #endregion //Method
    }
}
