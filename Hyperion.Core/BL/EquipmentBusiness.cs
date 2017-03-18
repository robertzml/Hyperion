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
    /// 设备业务类
    /// </summary>
    public class EquipmentBusiness : AbstractBusiness<Equipment, int>, IBaseBL<Equipment, int>
    {
        #region Constructor
        /// <summary>
        /// 设备业务类
        /// </summary>
        public EquipmentBusiness()
        {
            this.baseDal = RepositoryFactory<IEquipmentRepository>.Instance;
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
            var dal = this.baseDal as IEquipmentRepository;

            return dal.FindOne(userId, serialNumber);
        }

        /// <summary>
        /// 根据序列号查找设备
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public IEnumerable<Equipment> FindBySerialNumber(string serialNumber)
        {
            return this.baseDal.FindListByField("serialnumber", serialNumber);
        }

        /// <summary>
        /// 根据用户ID查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<Equipment> FindByUserId(int userId)
        {
            return this.baseDal.FindListByField("userid", userId);
        }
        #endregion //Method
    }
}
