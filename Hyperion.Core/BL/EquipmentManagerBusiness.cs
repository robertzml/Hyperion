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
    /// 设备管理业务类
    /// </summary>
    public class EquipmentManagerBusiness : AbstractBusiness<EquipmentManager, int>, IBaseBL<EquipmentManager, int>
    {
        #region Constructor
        /// <summary>
        /// 设备管理业务类
        /// </summary>
        public EquipmentManagerBusiness()
        {
            this.baseDal = RepositoryFactory<IEquipmentManagerRepository>.Instance;
        }
        #endregion //Constructor
    }
}
