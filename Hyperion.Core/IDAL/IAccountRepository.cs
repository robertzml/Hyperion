using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 用户数据访问接口
    /// </summary>
    internal interface IAccountRepository : IBaseDAL<Account, int>
    {
        /// <summary>
        /// 查找设备操控用户
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        IEnumerable<Account> FindByEquipment(string serialNumber);
    }
}
