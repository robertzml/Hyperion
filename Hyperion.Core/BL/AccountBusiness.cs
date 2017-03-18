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
    /// 用户业务类
    /// </summary>
    public class AccountBusiness : AbstractBusiness<Account, int>, IBaseBL<Account, int>
    {
        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public AccountBusiness()
        {
            this.baseDal = RepositoryFactory<IAccountRepository>.Instance;
        }
        #endregion //Constructor
    }
}
