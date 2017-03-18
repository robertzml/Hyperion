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
    /// 设备业务类
    /// </summary>
    public class EquipmentBusiness : AbstractBusiness<Equipment, int>, IBaseBL<Equipment, int>
    {
        #region Constructor
        /// <summary>
        /// 设备业务类
        /// </summary>
        public EquipmentBusiness()
        {
            this.baseDal = RepositoryFactory<IEquipmentRepository>.Instance;
        }
        #endregion //Constructor
    }
}
