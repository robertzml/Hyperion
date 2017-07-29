using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Protocol
{
    using Newtonsoft.Json;

    /// <summary>
    /// 登录请求
    /// </summary>
    public class LoginRequest : BaseRequest
    {
        #region Field
        /// <summary>
        /// 控制器
        /// </summary>
        private string contolller = "freemall/accountToApp/";
        #endregion //Field

        #region Method
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="osType">操作系统类型</param>
        /// <param name="loginType">登录方式</param>
        /// <returns></returns>
        public dynamic Login(string userName, string password, int osType, int loginType)
        {
            string url = string.Format("{0}{1}login?userName={2}&password={3}&phoneType={4}&loginType={5}",
                host, contolller, userName, password, osType, loginType);

            var content = Get(url);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            return obj;
        }
        #endregion //Method
    }
}
