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
    /// 版本更新业务类
    /// </summary>
    public class UpgradeVersionBusiness : AbstractBusiness<UpgradeVersion, int>, IBaseBL<UpgradeVersion, int>
    {
        #region Constructor
        /// <summary>
        /// 版本更新业务类
        /// </summary>
        public UpgradeVersionBusiness()
        {
            this.baseDal = RepositoryFactory<IUpgradeVersionRepository>.Instance;
        }
        #endregion //Constructor
    }
}
