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
    /// 设备故障业务类
    /// </summary>
    public class EquipmentAlarmBusiness : AbstractBusiness<EquipmentAlarm, long>, IBaseBL<EquipmentAlarm, long>
    {
        #region Constructor
        /// <summary>
        /// 故障业务类
        /// </summary>
        public EquipmentAlarmBusiness()
        {
            this.baseDal = RepositoryFactory<IEquipmentAlarmRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 分页方式获取数据
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<EquipmentAlarm> FindWithPage(int startPos, int count)
        {
            var dal = this.baseDal as IEquipmentAlarmRepository;

            return dal.FindWithPage(startPos, count);
        }

        /// <summary>
        /// 按用户查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<EquipmentAlarm> FindByUser(int userId)
        {
            return this.baseDal.FindListByField("userid", userId);
        }
        #endregion //Method
    }
}
