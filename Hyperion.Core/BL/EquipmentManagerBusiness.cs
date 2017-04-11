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
    /// 设备管理业务类
    /// </summary>
    public class EquipmentManagerBusiness : AbstractBusiness<EquipmentManager, int>, IBaseBL<EquipmentManager, int>
    {
        #region Constructor
        /// <summary>
        /// 设备管理业务类
        /// </summary>
        public EquipmentManagerBusiness()
        {
            this.baseDal = RepositoryFactory<IEquipmentManagerRepository>.Instance;
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
            return this.baseDal.FindOneByField("serialnumber", serialNumber);
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override EquipmentManager Create(EquipmentManager entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.State = 1;
            return base.Create(entity);
        }

        /// <summary>
        /// 编辑设备
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool Update(EquipmentManager entity)
        {
            entity.UpdateDate = DateTime.Now;
            return base.Update(entity);
        }
        #endregion //Method
    }
}
