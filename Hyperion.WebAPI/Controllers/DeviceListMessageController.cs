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
    using Hyperion.Core.Utility;

    /// <summary>
    /// 设备列表报文控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DeviceListMessageController : ApiController
    {
        #region Action
        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <param name="accessType">接入类型</param>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="houseNumber">House序号</param>
        /// <param name="roomNumber">Room序号</param>
        /// <returns></returns>
        [AccessFilter]
        public HttpResponseMessage Get(int accessType, string accessId, string imei, int houseNumber, int roomNumber)
        {
            try
            {
                DeviceListMessage message = new DeviceListMessage(accessType, accessId, imei, houseNumber, roomNumber);
                var msg = message.GetMessage();

                Logger.Instance.Debug(string.Format("device list msg: {0}", msg));

                EquipmentServerAction act = new EquipmentServerAction();
                var result = act.RequestToServer(msg);

                Logger.Instance.Debug(string.Format("device list result: {0}", result));

                DeviceListAckMessage ack = new DeviceListAckMessage();
                ack.ParseAck(result);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.DeviceListNode);
                return response;
            }
            catch (Exception e)
            {
                Logger.Instance.Exception("Device List: 异常", e);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        #endregion //Action
    }
}
