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
    /// 房间业务类
    /// </summary>
    public class RoomBusiness : AbstractBusiness<Room, int>, IBaseBL<Room, int>
    {
        #region Constructor
        /// <summary>
        /// 房间业务类
        /// </summary>
        public RoomBusiness()
        {
            this.baseDal = RepositoryFactory<IRoomRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public Room FindOne(int userId, int homeId, int roomId)
        {
            var dal = this.baseDal as IRoomRepository;
            return dal.FindOne(userId, homeId, roomId);
        }

        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <returns></returns>
        public IEnumerable<Room> FindInHome(int userId, int homeId)
        {
            var dal = this.baseDal as IRoomRepository;
            return dal.FindInHome(userId, homeId);
        }

        /// <summary>
        /// 按用户ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<Room> FindByUser(int userId)
        {
            return this.baseDal.FindListByField("userid", userId);
        }
        #endregion //Method
    }
}
