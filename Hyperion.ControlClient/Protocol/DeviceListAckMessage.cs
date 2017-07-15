using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    using Hyperion.ControlClient.Model;

    /// <summary>
    /// 用户设备列表查询响应报文
    /// 0x17
    /// </summary>
    public class DeviceListAckMessage : AckMessage
    {
        #region Field
        /// <summary>
        /// 用户设备列表信元
        /// </summary>
        private DeviceListNode deviceListNode;
        #endregion //Field

        #region Constructor
        public DeviceListAckMessage()
        {
            this.deviceListNode = new DeviceListNode();
            deviceListNode.DeviceNodes = new List<DeviceNode>();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 生成信元报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            throw new NotImplementedException();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 解析响应
        /// </summary>
        /// <param name="message">响应报文</param>
        public override void ParseAck(string message)
        {
            ParseMessageContent(message);

            if (this.messageContent.Tag != 0x17)
            {
                throw new TLVException(messageContent, 0x17, messageContent.Tag);
            }

            int index = 0;
            string content = messageContent.Value;
            while (index < messageContent.Length)
            {
                var tlv = ParseTLV(content, index);

                switch (tlv.Tag)
                {
                    case 0x13:
                        this.serverResult = tlv;
                        deviceListNode.ServerResult = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x01:
                        deviceListNode.AccessId = tlv.Value;
                        break;
                    case 0x103:
                        deviceListNode.HouseNumber = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x112:
                        deviceListNode.RoomNumber = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x120:
                        deviceListNode.DeviceCount = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x121:
                        var device = ParseDevice(tlv);
                        deviceListNode.DeviceNodes.Add(device);
                        break;
                    default:
                        throw new TLVException(tlv, "未知TLV类型");
                }

                index += tlv.TLVLength;
            }
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 用户设备列表信元
        /// </summary>
        public DeviceListNode DeviceListNode
        {
            get
            {
                return deviceListNode;
            }
        }
        #endregion //Property
    }
}
