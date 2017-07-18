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
    using Hyperion.ControlClient.Communication;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;

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
        public HttpResponseMessage Get(int accessType, string accessId, string imei)
        {
            LogoutMessage message = new LogoutMessage(accessType, accessId, imei);
            var msg = message.GetMessage();

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            LogoutAckMessage ack = new LogoutAckMessage();
            ack.ParseAck(content);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.ServerResult.Value);
            return response;
        }
        #endregion //Action
    }
}
