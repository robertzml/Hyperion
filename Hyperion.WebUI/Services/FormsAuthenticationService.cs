using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Hyperion.WebUI.Services
{
    /// <summary>
    /// 表单认证服务
    /// </summary>
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        #region Method
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="roleName">角色名</param>
        /// <param name="createPersistentCookie">是否保留</param>
        /// <returns></returns>
        public HttpCookie SignIn(string userName, string roleName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), createPersistentCookie,
                roleName, FormsAuthentication.FormsCookiePath);
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);

            return cookie;
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="createPersistentCookie">是否保留</param>
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
        #endregion //Method
    }
}