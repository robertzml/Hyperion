﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Protocol
{   
    using Newtonsoft.Json;
    using Hyperion.BizAdapter.Model;

    /// <summary>
    /// 注册请求
    /// </summary>
    public class RegisterRequest : BaseRequest
    {       
        #region Field
        /// <summary>
        /// 控制器
        /// </summary>
        private string contolller = "freemall/accountToApp/";
        #endregion //Field

        #region Method
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public ServerStatus GetVerifyCode(string phone)
        {       
            string url = string.Format("{0}{1}getVerifyCode?phone={2}", host, contolller, phone);
            
            var content = Get(url);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            ServerStatus status = new ServerStatus();
            status.code = obj.code;
            status.message = obj.message ?? "";

            return status;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="phone"></param>
        /// <param name="accountType"></param>
        /// <param name="imsi"></param>
        /// <param name="imei"></param>
        /// <param name="validateCode"></param>
        /// <param name="osType"></param>
        /// <param name="refereePhone"></param>
        public dynamic Register(string userName, string password, string phone, int accountType, string imsi, string imei, string validateCode, int osType, string refereePhone)
        {
            string url = string.Format("{0}{1}register?userName={2}&password={3}&phone={4}&accountType={5}&imsi={6}&imei={7}&validateCode={8}&OsType={9}&refereePhone={10}",
                host, contolller, userName, password, phone, accountType, imsi, imei, validateCode, osType, refereePhone);
                       
            var content = Get(url);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            return obj;
        }
        #endregion //Method
    }
}
