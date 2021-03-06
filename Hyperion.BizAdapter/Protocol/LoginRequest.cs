﻿using System;
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
        /// <param name="imei">IMEI</param>
        /// <param name="sessionId">取出的Session</param>
        /// <returns></returns>
        public dynamic Login(string userName, string password, int osType, int loginType, string imei, out string sessionId)
        {
            string url = "";
            if (loginType == 3)
            {
                url = string.Format("{0}{1}login?phone={2}&password={3}&osType={4}&loginType={5}&imei={6}",
                    host, contolller, userName, password, osType, loginType, imei);
            }
            else
            {
                url = string.Format("{0}{1}login?userName={2}&password={3}&osType={4}&loginType={5}&imei={6}",
                    host, contolller, userName, password, osType, loginType, imei);
            }

            // var content = Get(url);
            var result = GetContentAndHeader(url, "Set-Cookie");

            dynamic obj = JsonConvert.DeserializeObject<dynamic>(result.Item1);
            sessionId = result.Item2;

            return obj;
        }
        #endregion //Method
    }
}
