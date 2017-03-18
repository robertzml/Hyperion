using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 设备数据访问接口
    /// </summary>
    internal interface IEquipmentRepository : IBaseDAL<Equipment, int>
    {
        /// <summary>
        /// 根据用户ID和序列号查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        Equipment FindOne(int userId, string serialNumber);
    }
}
