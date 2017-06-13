using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 故障数据访问接口
    /// </summary>
    internal interface IEquipmentAlarmRepository : IBaseDAL<EquipmentAlarm, long>
    {
        /// <summary>
        /// 分页方式查找对象
        /// </summary>
        /// <param name="startPos">起始位置</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        IEnumerable<EquipmentAlarm> FindWithPage(int startPos, int count);
    }
}
