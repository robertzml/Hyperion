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
    using Hyperion.WebAPI.Utility;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;

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
        public HttpResponseMessage Get(int accessType, string accessId, string imei, int houseNumber, int roomNumber)
        {
            DeviceListMessage message = new DeviceListMessage(accessType, accessId, imei, houseNumber, roomNumber);
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
