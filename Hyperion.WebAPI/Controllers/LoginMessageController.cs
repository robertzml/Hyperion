using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Hyperion.WebAPI.Controllers
{
    using log4net;
    using Poseidon.Common;
    using Hyperion.BizAdapter.Protocol;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;
    using Hyperion.WebAPI.Utility;
    using Hyperion.WebAPI.Models;

    /// <summary>
    /// 登录报文控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginMessageController : ApiController
    {
        #region Action       
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="imei">IMEI</param>
        /// <param name="userLoginType">用户登录标识</param>
        /// <param name="getStatus">取得设备列表</param>
        /// <returns></returns>
        [RequireHttps]
        [AccessFilter]
        private HttpResponseMessage Get(string accessId, long userId, int userType, string imei, int userLoginType, int getStatus)
        {
            try
            {
                LoginMessage message = new LoginMessage(accessId, userId, userType, imei, userLoginType, getStatus);
                var msg = message.GetMessage();

                EquipmentServerAction act = new EquipmentServerAction();
                var result = act.RequestToServer(msg);

                LoginAckMessage ack = new LoginAckMessage();
                ack.ParseAck(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.LoginNode);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="password">密码</param>
        /// <param name="osType">操作系统类型</param>
        /// <param name="userType">用户类型</param>
        /// <param name="imei">IMEI</param>
        /// <param name="userLoginType">用户登录标识</param>
        /// <param name="getStatus">取得设备列表</param>
        /// <returns></returns>
        [AccessFilter]
        [ResponseType(typeof(LoginModel))]
        public HttpResponseMessage Get2(string accessId, string password, int osType, int userType, string imei, int userLoginType, int getStatus)
        {
            try
            {
                LoginRequest request = new LoginRequest();
                dynamic obj = request.Login(accessId, password, osType, userLoginType, imei);

                LoginModel model = new LoginModel();
                model.BizStatus = new BizAdapter.Model.ServerStatus();
                model.BizStatus.Code = obj.status.code;
                model.BizStatus.Message = obj.status.message;

                if (model.BizStatus.Code == 0)
                {
                    model.LoginResult = new BizAdapter.Model.LoginResult();
                    model.LoginResult.UserId = obj.result.accountId;
                    model.LoginResult.Phone = obj.result.phone;
                    model.LoginResult.Picture = obj.result.picture;

                    LoginMessage message = new LoginMessage(accessId, model.LoginResult.UserId, userType, imei, userLoginType, getStatus);
                    var msg = message.GetMessage();

                    EquipmentServerAction act = new EquipmentServerAction();
                    var result = act.RequestToServer(msg);

                    LoginAckMessage ack = new LoginAckMessage();
                    ack.ParseAck(result);

                    model.LoginNode = ack.LoginNode;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                    return response;
                }
            }
            catch (Exception e)
            {
                var logger = LogManager.GetLogger(typeof(LoginMessageController));
                logger.Error(e.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion //Action
    }
}
