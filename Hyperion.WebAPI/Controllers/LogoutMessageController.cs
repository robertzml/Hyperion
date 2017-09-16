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
    /// 登录报文控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LogoutMessageController : ApiController
    {
        #region Action
        /// <summary>
        /// 用户注销
        /// </summary>
        /// <param name="accessType">接入类型</param>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <returns></returns>
        [AccessFilter]
        public HttpResponseMessage Get(int accessType, string accessId, string imei)
        {
            try
            {
                LogoutRequest request = new LogoutRequest();
                dynamic obj = request.Logout(accessId);

                LogoutModel model = new LogoutModel();
                model.Code = obj.status.code;
                model.Message = obj.status.message;

                if (model.Code == 0)
                {
                    LogoutMessage message = new LogoutMessage(accessType, accessId, imei);
                    var msg = message.GetMessage();

                    EquipmentServerAction act = new EquipmentServerAction();
                    var result = act.RequestToServer(msg);

                    LogoutAckMessage ack = new LogoutAckMessage();
                    ack.ParseAck(result);

                    model.ServerResult = Convert.ToInt32(ack.ServerResult.Value, 16);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                    return response;
                }
                else
                {
                    model.ServerResult = 1;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
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
