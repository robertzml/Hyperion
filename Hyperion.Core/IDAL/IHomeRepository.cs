using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 房屋数据访问接口
    /// </summary>
    internal interface IHomeRepository : IBaseDAL<Home, int>
    {
        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <returns></returns>
        Home FindOne(int userId, int homeId);
    }
}
