using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Protocol
{
    using Newtonsoft.Json;

    /// <summary>
    /// 注销请求
    /// </summary>
    public class LogoutRequest : BaseRequest
    {
        #region Field
        /// <summary>
        /// 控制器
        /// </summary>
        private string contolller = "freemall/accountToApp/";
        #endregion //Field

        #region Method
        /// <summary>
        /// 用户注销
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public dynamic Logout(string userName)
        {
            string url = string.Format("{0}{1}logOut?userName={2}",
                host, contolller, userName);

            var content = Get(url);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            return obj;
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        /// <param name="accountId">用户Id</param>
        /// <param name="imei">IMEI</param>
        /// <param name="cookie">Cookie</param>
        /// <returns></returns>
        public dynamic Logout(int accountId, string imei, string cookie)
        {
            string url = string.Format("{0}{1}logOut?accountId={2}&imei={3}",
                host, contolller, accountId, imei);

            var content = GetWithCookie(url, cookie);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            return obj;
        }
        #endregion //Method
    }
}
