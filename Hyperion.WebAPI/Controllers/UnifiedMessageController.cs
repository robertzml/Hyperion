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
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;

    /// <summary>
    /// 统一操作控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UnifiedMessageController : ApiController
    {
        #region Action       
        /// <summary>
        /// 增加设备
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="houseNumber">House序号</param>
        /// <param name="roomNumber">Room序号</param>
        /// <param name="deviceName">设备名称</param>
        /// <param name="deviceType">设备类型</param>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        public HttpResponseMessage GetAdd(string accessId, string imei, int houseNumber, int roomNumber, string deviceName, string deviceType, string serialNumber)
        {
            UnifiedMessage message = new UnifiedMessage(accessId, imei, houseNumber, roomNumber, deviceName, deviceType, serialNumber);
            var msg = message.GetMessage();

            EquipmentServerAction act = new EquipmentServerAction();
            var result = act.RequestToServer(msg);

            DeviceListAckMessage ack = new DeviceListAckMessage();
            ack.ParseAck(result);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.DeviceListNode);
            return response;
        }

        /// <summary>
        /// 修改设备
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="deviceName">设备名称</param>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        public HttpResponseMessage GetEdit(string accessId, string imei, string deviceName, string serialNumber)
        {
            UnifiedMessage message = new UnifiedMessage(accessId, imei, deviceName, serialNumber);
            var msg = message.GetMessage();

            EquipmentServerAction act = new EquipmentServerAction();
            var result = act.RequestToServer(msg);

            DeviceListAckMessage ack = new DeviceListAckMessage();
            ack.ParseAck(result);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.DeviceListNode);
            return response;
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="accessId">接入ID</param>
        /// <param name="imei">IMEI</param>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        public HttpResponseMessage GetDelete(string accessId, string imei, string serialNumber)
        {
            UnifiedMessage message = new UnifiedMessage(accessId, imei, serialNumber);
            var msg = message.GetMessage();

            EquipmentServerAction act = new EquipmentServerAction();
            var result = act.RequestToServer(msg);

            DeviceListAckMessage ack = new DeviceListAckMessage();
            ack.ParseAck(result);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ack.DeviceListNode);
            return response;
        }
        #endregion //Action
    }
}
