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
    /// 设备状态业务类
    /// </summary>
    public class EquipmentStateBusiness : AbstractBusiness<EquipmentState, long>, IBaseBL<EquipmentState, long>
    {
        #region Constructor
        /// <summary>
        /// 设备状态业务类
        /// </summary>
        public EquipmentStateBusiness()
        {
            this.baseDal = RepositoryFactory<IEquipmentStateRepository>.Instance;
        }
        #endregion //Constructor
    }
}
