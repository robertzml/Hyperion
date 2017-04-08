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
    /// 管理用户访问服务接口
    /// </summary>
    public interface IUserInfoService :　IBaseService<UserInfo, int>
    {
        /// <summary>
        /// 按用户名查找
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        UserInfo FindByUserName(string username);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        bool Login(string username, string password);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="oldPass">原密码</param>
        /// <param name="newPass">新密码</param>
        /// <returns></returns>
        /// <remarks>
        /// 加密过程在客户端处理
        /// </remarks>
        bool ChangePassword(int id, string oldPass, string newPass);
    }
}
