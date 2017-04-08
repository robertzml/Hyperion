using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 房间数据访问接口
    /// </summary>
    internal interface IRoomRepository : IBaseDAL<Room, int>
    {
        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        Room FindOne(int userId, int homeId, int roomId);

        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <returns></returns>
        IEnumerable<Room> FindInHome(int userId, int homeId);
    }
}
