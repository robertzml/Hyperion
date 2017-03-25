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
    /// 设备管理访问服务类
    /// </summary>
    internal class EquipmentManagerService : AbstractLocalService<EquipmentManager, int>, IEquipmentManagerService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private EquipmentManagerBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 设备管理访问服务类
        /// </summary>
        public EquipmentManagerService() : base(BusinessFactory<EquipmentManagerBusiness>.Instance)
        {
            this.bl = this.baseBL as EquipmentManagerBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据序列号查找设备
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public EquipmentManager FindBySerialNumber(string serialNumber)
        {
            return this.bl.FindBySerialNumber(serialNumber);
        }
        #endregion //Method
    }
}
