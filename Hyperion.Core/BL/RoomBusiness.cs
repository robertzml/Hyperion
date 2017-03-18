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
    }
}
