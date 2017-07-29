using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Protocol
{   
    using Newtonsoft.Json;

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
        public dynamic GetVerifyCode(string phone)
        {       
            string url = string.Format("{0}{1}getVerifyCode?phone={2}", host, contolller, phone);
            
            var content = Get(url);

            dynamic newValue = JsonConvert.DeserializeObject<dynamic>(content);

            return newValue;
        }
        #endregion //Method
    }
}
