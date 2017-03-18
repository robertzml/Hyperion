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
    /// 用户信息业务类
    /// </summary>
    public class AccountInfoBusiness : AbstractBusiness<AccountInfo, int>, IBaseBL<AccountInfo, int>
    {
        #region Constructor
        /// <summary>
        /// 用户信息业务类
        /// </summary>
        public AccountInfoBusiness()
        {
            this.baseDal = RepositoryFactory<IAccountInfoRepository>.Instance;
        }
        #endregion //Constructor
    }
}
