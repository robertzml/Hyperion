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

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.ServerResult.Value);
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
