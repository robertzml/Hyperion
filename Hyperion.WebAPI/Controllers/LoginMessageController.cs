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
    public class LoginMessageController : ApiController
    {
        #region Action
        /// <summary>
        /// 用户登录
        /// </summary>
        public HttpResponseMessage Get(string accessId, long userId, int userType, string imei, int userLoginType, int getStatus)
        {
            LoginMessage message = new LoginMessage(accessId, userId, userType, imei, userLoginType, getStatus);
            var msg = message.GetMessage();

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            LoginAckMessage ack = new LoginAckMessage();
            ack.ParseAck(content);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.LoginNode);
            return response;
        }
        #endregion //Action
    }
}
