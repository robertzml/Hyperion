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
    /// 设备访问服务类
    /// </summary>
    internal class EquipmentService : AbstractLocalService<Equipment, long>, IEquipmentService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private EquipmentBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 设备访问服务类
        /// </summary>
        public EquipmentService() : base(BusinessFactory<EquipmentBusiness>.Instance)
        {
            this.bl = this.baseBL as EquipmentBusiness;
        }
        #endregion //Constructor
    }
}
