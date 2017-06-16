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
    /// 设备访问服务接口
    /// </summary>
    public interface IEquipmentService : IBaseService<Equipment, long>
    {
    }
}
