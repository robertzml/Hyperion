using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 用户信息数据访问接口
    /// </summary>
    internal interface IAccountInfoRepository : IBaseDAL<AccountInfo, int>
    {
    }
}
