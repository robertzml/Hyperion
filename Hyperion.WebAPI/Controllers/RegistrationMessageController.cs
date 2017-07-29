using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hyperion.WebAPI.Controllers
{
    using Hyperion.BizAdapter.Protocol;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;
    using Hyperion.WebAPI.Utility;

    /// <summary>
    /// 注册报文控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationMessageController : ApiController
    {
        #region Action
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerType">注册类型</param>
        /// <param name="accessId">接入ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="imei">IMEI</param>
        /// <returns></returns>
        [AccessFilter]
        public HttpResponseMessage Get(int registerType, string accessId, long userId, int userType, string imei)
        {
            try
            {
                RegistrationMessage message = new RegistrationMessage(registerType, accessId, userId, userType, imei);
                var msg = message.GetMessage();

                EquipmentServerAction act = new EquipmentServerAction();
                var result = act.RequestToServer(msg);

                RegistrationAckMessage ack = new RegistrationAckMessage();
                ack.ParseAck(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.RegistrationNode);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="accessId">手机号</param>
        /// <returns></returns>
        public HttpResponseMessage GetVerifyCode(string phone, string accessId)
        {
            try
            {
                RegisterRequest request = new RegisterRequest();
                dynamic data = request.GetVerifyCode(phone);

                var result = new
                {
                    Message = Convert.ToString(data.status.message),
                    Code = Convert.ToInt32(data.status.code)
                };

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion //Action
    }
}
