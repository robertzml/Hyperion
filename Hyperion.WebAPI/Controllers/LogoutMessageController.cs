using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Hyperion.WebAPI.Controllers
{
    using Hyperion.BizAdapter.Protocol;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;
    using Hyperion.Core.Utility;
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
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        [AccessFilter]
        [ResponseType(typeof(LogoutModel))]
        public HttpResponseMessage Get(int accessType, string accessId, string imei, int accountId)
        {
            try
            {
                var cos = Request.Headers.GetValues("Cookie").ToList();
                if (cos.Count == 0)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
                    return response;
                }

                var cookie = cos[0];

                Logger.Instance.Debug("Logout accessId:" + accessId);

                LogoutRequest request = new LogoutRequest();
                dynamic obj = request.Logout(accountId, imei, cookie);

                LogoutModel model = new LogoutModel();
                model.Code = obj.code;
                model.Message = obj.message;

                if (model.Code == 0)
                {
                    string encodeAccessId = HttpUtility.UrlEncode(accessId);

                    LogoutMessage message = new LogoutMessage(accessType, encodeAccessId, imei);
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
