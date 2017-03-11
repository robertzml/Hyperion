using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.DAL.MySql
{
    using Poseidon.Base.System;
    using Poseidon.Data;
    using Hyperion.Core.Abstract;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;

    /// <summary>
    /// 管理用户数据访问类
    /// </summary>
    internal class UserInfoRepository : AbstractDALMySql<UserInfo>, IUserInfoRepository
    {
        #region Function

        #endregion //Function
        protected override Hashtable EntityToHash(UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
