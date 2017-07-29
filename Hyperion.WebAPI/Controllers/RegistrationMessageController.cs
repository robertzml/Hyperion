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
    using Hyperion.WebAPI.Models;

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
        /// <returns>
        /// { Message: "", Code: 1 }
        /// </returns>
        [AccessFilter]
        public HttpResponseMessage GetVerifyCode(string phone, string accessId)
        {
            try
            {
                RegisterRequest request = new RegisterRequest();
                var data = request.GetVerifyCode(phone);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerType">注册类型</param>
        /// <param name="accessId">接入ID</param>
        /// <param name="password">密码</param>
        /// <param name="phone">手机号</param>
        /// <param name="userType">用户类型</param>
        /// <param name="imsi">IMSI</param>
        /// <param name="imei">IMEI</param>
        /// <param name="validateCode">验证码</param>
        /// <param name="osType">操作系统类型</param>
        /// <returns></returns>
        /// <remarks>
        /// 先在业务服务器注册，再在设备服务注册
        /// </remarks>
        [AccessFilter]
        public HttpResponseMessage GetRegister(int registerType, string accessId, string password, string phone, int userType, string imsi, string imei, string validateCode, int osType)
        {
            try
            {
                RegisterRequest request = new RegisterRequest();
                dynamic obj = request.Register(accessId, password, phone, userType, imsi, imei, validateCode, osType);

                RegisterModel registerModel = new RegisterModel();
                registerModel.Code = obj.status.code;
                registerModel.Message = obj.status.message;

                if (registerModel.Code == 1)
                {
                    int userId = obj.result.accountId;

                    RegistrationMessage message = new RegistrationMessage(registerType, accessId, userId, userType, imei);
                    var msg = message.GetMessage();

                    EquipmentServerAction act = new EquipmentServerAction();
                    var result = act.RequestToServer(msg);

                    RegistrationAckMessage ack = new RegistrationAckMessage();
                    ack.ParseAck(result);

                    registerModel.ServerResult = ack.RegistrationNode.ServerResult;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, registerModel);
                    return response;
                }
                else
                {
                    registerModel.ServerResult = 1;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, registerModel);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion //Action
    }
}
