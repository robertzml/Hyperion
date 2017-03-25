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
    /// 设备管理访问服务接口
    /// </summary>
    public interface IEquipmentManagerService : IBaseService<EquipmentManager, int>
    {
        /// <summary>
        /// 根据序列号查找设备
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        EquipmentManager FindBySerialNumber(string serialNumber);
    }
}
