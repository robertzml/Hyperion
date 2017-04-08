using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.WebUI.Services
{
    interface IFormsAuthenticationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="roleName">角色名</param>
        /// <param name="createPersistentCookie">是否保留</param>
        /// <returns></returns>
        System.Web.HttpCookie SignIn(string userName, string roleName, bool createPersistentCookie);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="createPersistentCookie">是否保留</param>
        void SignIn(string userName, bool createPersistentCookie);

        /// <summary>
        /// 注销
        /// </summary>
        void SignOut();
    }
}
