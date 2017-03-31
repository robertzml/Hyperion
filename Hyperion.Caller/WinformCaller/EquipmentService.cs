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
    /// 用户设备访问服务类
    /// </summary>
    internal class EquipmentService : AbstractLocalService<Equipment, int>, IEquipmentService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private EquipmentBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户设备访问服务类
        /// </summary>
        public EquipmentService() : base(BusinessFactory<EquipmentBusiness>.Instance)
        {
            this.bl = this.baseBL as EquipmentBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据用户ID和序列号查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public Equipment FindOne(int userId, string serialNumber)
        {
            return this.bl.FindOne(userId, serialNumber);
        }

        /// <summary>
        /// 根据序列号查找设备
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public IEnumerable<Equipment> FindBySerialNumber(string serialNumber)
        {
            return this.bl.FindBySerialNumber(serialNumber);
        }

        /// <summary>
        /// 根据用户ID查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<Equipment> FindByUserId(int userId)
        {
            return this.bl.FindByUserId(userId);
        }
        #endregion //Method
    }
}
