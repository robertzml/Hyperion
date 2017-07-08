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
    /// 用户设备业务类
    /// </summary>
    public class UserEquipmentBusiness : AbstractBusiness<UserEquipment, long>, IBaseBL<UserEquipment, long>
    {
        #region Constructor
        /// <summary>
        /// 用户设备业务类
        /// </summary>
        public UserEquipmentBusiness()
        {
            this.baseDal = RepositoryFactory<IUserEquipmentRepository>.Instance;
        }
        #endregion //Constructor
    }
}
