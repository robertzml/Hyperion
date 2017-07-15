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
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;

    /// <summary>
    /// 注册报文控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationMessageController : ApiController
    {
        #region Action
        /// <summary>
        /// 获取设备列表
        /// </summary>
        public HttpResponseMessage Get(int registerType, string accessId, long userId, int userType, string imei)
        {
            RegistrationMessage message = new RegistrationMessage(registerType, accessId, userId, userType, imei);
            var msg = message.GetMessage();

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            RegistrationAckMessage ack = new RegistrationAckMessage();
            ack.ParseAck(content);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.ServerResult.Value);
            return response;
        }
        #endregion //Action
    }
}
