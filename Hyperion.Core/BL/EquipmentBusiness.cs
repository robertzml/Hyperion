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
    public class EquipmentBusiness : AbstractBusiness<Equipment, string>, IBaseBL<Equipment, string>
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
        /// 添加设备，采用自定义主键
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Equipment Create(Equipment entity)
        {
            return base.Create(entity, false);
        }

        /// <summary>
        /// 按序列号查找设备
        /// </summary>
        /// <param name="serialName">序列号</param>
        /// <returns></returns>
        public Equipment FindBySerialName(string serialName)
        {
            return this.baseDal.FindOneByField("serial_name", serialName);
        }
        #endregion //Method
    }
}
