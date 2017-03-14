using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.BL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;

    /// <summary>
    /// 厂家业务类
    /// </summary>
    public class VendorInfoBusiness : AbstractBusiness<VendorInfo, int>, IBaseBL<VendorInfo, int>
    {
        #region Constructor
        /// <summary>
        /// 厂家业务类
        /// </summary>
        public VendorInfoBusiness()
        {
            this.baseDal = RepositoryFactory<IVendorInfoRepository>.Instance;
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
            return this.baseDal.FindOneByField("vendor_name", name);
        }
        #endregion //Method
    }
}
