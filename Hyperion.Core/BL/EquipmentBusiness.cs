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
    public class EquipmentBusiness : AbstractBusiness<Equipment, long>, IBaseBL<Equipment, long>
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
        /// 按序列号查找设备
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public Equipment FindBySerialNumber(string serialNumber)
        {
            return this.baseDal.FindOneByField("serial_number", serialNumber);
        }

        /// <summary>
        /// 按厂商查找设备
        /// </summary>
        /// <param name="vendor">厂商</param>
        /// <returns></returns>
        public IEnumerable<Equipment> FindByVendor(string vendor)
        {
            return this.baseDal.FindListByField("vendor", vendor);
        }
        #endregion //Method
    }
}
