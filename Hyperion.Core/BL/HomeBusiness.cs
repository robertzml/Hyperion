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
    /// 房屋业务类
    /// </summary>
    public class HomeBusiness : AbstractBusiness<Home, int>, IBaseBL<Home, int>
    {
        #region Constructor
        /// <summary>
        /// 房屋业务类
        /// </summary>
        public HomeBusiness()
        {
            this.baseDal = RepositoryFactory<IHomeRepository>.Instance;
        }
        #endregion //Constructor
    }
}
