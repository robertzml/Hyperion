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
    using Hyperion.BizAdapter.Model;
    using Hyperion.ControlClient.Model;
    using Hyperion.ControlClient.Protocol;
    using Hyperion.Core.Utility;
    using Hyperion.WebAPI.Utility;

    /// <summary>
    /// 统一操作控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UnifiedMessageController : ApiController
    {
        #region Action
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="accountId">用户ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="phone">手机号</param>
        /// <param name="serialNumber">序列号</param>
        /// <returns>
        /// { Message: "", Code: 1 }
        /// </returns>
        [ResponseType(typeof(ServerStatus2))]
        public HttpResponseMessage GetVerifyCode(int accountId, string imei, string phone, string serialNumber)
        {
            try
            {
                UnifyRequest request = new UnifyRequest();
                var data = request.GetVerifyCode(accountId, imei, phone, serialNumber);

                Logger.Instance.Debug(string.Format("API Get Verify : code={0}, message={1}, isowner", data.Code, data.Message, data.IsOwner));

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
                return response;
            }
            catch (Exception e)
            {
                Logger.Instance.Exception("API Unified Get Code: 异常", e);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// 增加设备
        /// </summary>
        /// <param name="accountId">用户ID</param>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="houseNumber">House序号</param>
        /// <param name="roomNumber">Room序号</param>
        /// <param name="deviceName">设备名称</param>
        /// <param name="deviceType">设备类型</param>
        /// <param name="serialNumber">设备序列号</param>
        /// <param name="verifyCode">验证码</param>
        /// <param name="userPhone">用户手机</param>
        /// <returns></returns>
        [AccessFilter]
        public HttpResponseMessage GetAdd(int accountId, string accessId, string imei, int houseNumber, int roomNumber, string deviceName, string deviceType, string serialNumber, string verifyCode, string userPhone)
        {
            try
            {
                Logger.Instance.Debug(string.Format("API Unified Add2 Send: accountId={0}, accessId={1}, imei={2}, houseNumber={3}, roomNumber={4}, deviceName={5}, deviceType={6}, serailNumber={7}, verifyCode={8}",
                    accountId, accessId, imei, houseNumber, roomNumber, deviceName, deviceType, serialNumber, verifyCode));

                var cos = Request.Headers.GetValues("Cookie").ToList();
                if (cos.Count == 0)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
                    return response;
                }

                var cookie = cos[0];

                UnifyRequest request = new UnifyRequest();
                var res = request.CheckVerifyCode(accountId, imei, verifyCode, cookie);

                Logger.Instance.Debug(string.Format("API Unified Add2: code={0}, message={1}", res.code, res.message));

                if (res.code == 0)
                {
                    string encodeAccessId = HttpUtility.UrlEncode(accessId);
                    string encodeDeviceName = HttpUtility.UrlEncode(deviceName);

                    UnifiedMessage message = new UnifiedMessage(encodeAccessId, imei, houseNumber, roomNumber, encodeDeviceName, deviceType, serialNumber, userPhone);
                    var msg = message.GetMessage();

                    Logger.Instance.Debug(string.Format("API Unified Add2 Get Message:{0}", msg));

                    EquipmentServerAction act = new EquipmentServerAction();
                    var result = act.RequestToServer(msg);

                    Logger.Instance.Debug(string.Format("API Unified Add2 RequestToServer result:{0}", result));

                    UnifiedAckMessage ack = new UnifiedAckMessage();
                    ack.ParseAck(result);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.UnifiedNode);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, res);
                    return response;
                }
            }
            catch (Exception e)
            {
                Logger.Instance.Exception("API Add Device: 异常", e);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// 修改设备
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="deviceName">设备名称</param>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [AccessFilter]
        public HttpResponseMessage GetEdit(string accessId, string imei, string deviceName, string serialNumber)
        {
            try
            {
                string encodeAccessId = HttpUtility.UrlEncode(accessId);
                string encodeDeviceName = HttpUtility.UrlEncode(deviceName);

                UnifiedMessage message = new UnifiedMessage(encodeAccessId, imei, encodeDeviceName, serialNumber);
                var msg = message.GetMessage();

                EquipmentServerAction act = new EquipmentServerAction();
                var result = act.RequestToServer(msg);

                UnifiedAckMessage ack = new UnifiedAckMessage();
                ack.ParseAck(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.UnifiedNode);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [AccessFilter]
        public HttpResponseMessage GetDelete(string accessId, string imei, string serialNumber)
        {
            try
            {
                string encodeAccessId = HttpUtility.UrlEncode(accessId);

                UnifiedMessage message = new UnifiedMessage(encodeAccessId, imei, serialNumber);
                var msg = message.GetMessage();

                EquipmentServerAction act = new EquipmentServerAction();
                var result = act.RequestToServer(msg);

                UnifiedAckMessage ack = new UnifiedAckMessage();
                ack.ParseAck(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.UnifiedNode);
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
