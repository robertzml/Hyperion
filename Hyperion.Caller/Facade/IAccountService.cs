using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 设备用户访问服务接口
    /// </summary>
    public interface IAccountService : IBaseService<Account, int>
    {
        /// <summary>
        /// 按用户名查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Account FindByName(string userName);
    }
}
