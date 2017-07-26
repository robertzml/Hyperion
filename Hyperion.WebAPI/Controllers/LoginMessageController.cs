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
    using Poseidon.Common;
    using Hyperion.ControlClient.Communication;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;
    using Hyperion.WebAPI.Utility;

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
        public HttpResponseMessage Get(string accessId, long userId, int userType, string imei, int userLoginType, int getStatus)
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
        #endregion //Action
    }
}
