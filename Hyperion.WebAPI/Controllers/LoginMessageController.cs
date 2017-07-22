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
        public HttpResponseMessage Get(string accessId, long userId, int userType, string imei, int userLoginType, int getStatus)
        {
            if (!Request.Headers.Contains("auth"))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, HttpErrorMessage.BadRequest.DisplayName());
            else
            {
                var auth = Request.Headers.GetValues("auth").First();

                if (auth != Hasher.SHA1Encrypt(accessId + HyperionConstant.Salt))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, HttpErrorMessage.AuthFailed.DisplayName());
            }

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
