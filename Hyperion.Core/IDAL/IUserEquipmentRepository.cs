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
    /// 用户设备数据访问接口
    /// </summary>
    internal interface IUserEquipmentRepository : IBaseDAL<UserEquipment, long>
    {
    }
}
