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

        #region Method
        /// <summary>
        /// 按用户名查找用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public AccountInfo FindByUserName(string userName)
        {
            return this.baseDal.FindOneByField("username", userName);
        }
        #endregion //Method
    }
}
