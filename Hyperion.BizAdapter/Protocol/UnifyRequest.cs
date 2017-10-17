using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Protocol
{
    using Newtonsoft.Json;
    using Hyperion.BizAdapter.Model;

    /// <summary>
    /// 设备操作相关业务请求
    /// </summary>
    public class UnifyRequest : BaseRequest
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
        public ServerStatus2 GetVerifyCode(int accountId, string imei, string phone, string serialNumber)
        {
            string url = string.Format("{0}{1}addDeviceGetVerifyCode?accountid={2}&imei={3}&phone={4}&serialnumber={5}", host, contolller, accountId, imei, phone, serialNumber);

            var content = Get(url);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            ServerStatus2 status = new ServerStatus2();
            status.Code = obj.code;
            if (status.Code != 0)
                status.Message = obj.message;
            status.IsOwner = obj.isowner;

            return status;
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="accountId">用户ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        public ServerStatus CheckVerifyCode(int accountId, string imei, string verifyCode)
        {
            string url = string.Format("{0}{1}addDeviceCheckVerifyCode?accountid={2}&imei={3}&verifycode={4}", host, contolller, accountId, imei, verifyCode);

            var content = Get(url);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(content);

            ServerStatus status = new ServerStatus();
            status.code = obj.code;
            status.message = obj.message;

            return status;
        }
        #endregion //Method
    }
}
