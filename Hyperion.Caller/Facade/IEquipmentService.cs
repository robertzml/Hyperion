using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 用户设备访问服务接口
    /// </summary>
    public interface IEquipmentService : IBaseService<Equipment, int>
    {
        /// <summary>
        /// 根据用户ID和序列号查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        Equipment FindOne(int userId, string serialNumber);

        /// <summary>
        /// 根据序列号查找设备
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        IEnumerable<Equipment> FindBySerialNumber(string serialNumber);

        /// <summary>
        /// 根据用户ID查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        IEnumerable<Equipment> FindByUserId(int userId);
    }
}
