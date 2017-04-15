using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Hyperion.WebUI.Services
{
    public static class ModelExtension
    {
        #region Method
        /// <summary>
        /// 自定义角色判断
        /// </summary>
        /// <param name="user">当前用户信息</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public static bool IsInRole2(this IPrincipal user, string role)
        {
            if (user != null && user.Identity.IsAuthenticated)
            {
                FormsIdentity fi = (FormsIdentity)user.Identity;
                string[] roles = fi.Ticket.UserData.Split(',');
                if (roles.Contains(role))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        #endregion //Method
    }
}