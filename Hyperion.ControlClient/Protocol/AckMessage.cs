using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    using Hyperion.ControlClient.Model;

    /// <summary>
    /// 响应报文
    /// </summary>
    public abstract class AckMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 服务器操作结果
        /// </summary>
        protected TLV serverResult;
        #endregion //Field

        #region Function
        /// <summary>
        /// 解析协议头
        /// </summary>
        /// <param name="message">报文</param>
        /// <returns></returns>
        protected virtual int ParseHead(string message)
        {
            var ackVersion = message.Substring(0, this.version.Length);
            this.sequence = Convert.ToInt32(message.Substring(this.version.Length, 8), 16);

            var messageHead = message.Substring(this.version.Length + 8, 8);

            var headType = messageHead.Substring(0, 4);
            this.infoCode = Convert.ToInt32(headType, 16);

            var messageLength = Convert.ToInt32(messageHead.Substring(4, 4), 16);

            return messageLength;
        }

        /// <summary>
        /// 解析报文内容，仅解出头部
        /// </summary>
        /// <param name="message">报文</param>
        /// <returns></returns>
        protected virtual void ParseMessageContent(string message)
        {
            var ackVersion = message.Substring(0, this.version.Length);
            this.sequence = Convert.ToInt32(message.Substring(this.version.Length, 8), 16);

            var head = ParseTLV(message, this.version.Length + 8);

            this.messageContent = head;
        }

        /// <summary>
        /// 解析房屋
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual HouseNode ParseHouse(TLV message)
        {
            if (message.Tag != 0x102)
            {
                throw new TLVException(message, 0x102, message.Tag);
            }

            HouseNode house = new HouseNode();
            house.roomnodes = new List<RoomNode>();

            int index = 0;
            string content = message.Value;

            while (index < message.Length)
            {
                var tlv = ParseTLV(content, index);

                switch (tlv.Tag)
                {
                    case 0x103:
                        house.number = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x104:
                        house.name = tlv.Value;
                        break;
                    case 0x106:
                        house.info = tlv.Value;
                        break;
                    case 0x107:
                        house.position = tlv.Value;
                        break;
                    case 0x110:
                        house.roomcount = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x111:
                        var room = ParseRoom(tlv);
                        house.roomnodes.Add(room);
                        break;
                }

                index += tlv.TLVLength;
            }

            return house;
        }

        /// <summary>
        /// 解析Room
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual RoomNode ParseRoom(TLV message)
        {
            if (message.Tag != 0x111)
            {
                throw new TLVException(message, 0x111, message.Tag);
            }

            RoomNode room = new RoomNode();
            room.devicenodes = new List<DeviceNode>();

            int index = 0;
            string content = message.Value;

            while (index < message.Length)
            {
                var tlv = ParseTLV(content, index);

                switch (tlv.Tag)
                {
                    case 0x112:
                        room.number = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x113:
                        room.name = tlv.Value;
                        break;
                    case 0x114:
                        room.type = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x120:
                        room.devicecount = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x121:
                        var device = ParseDevice(tlv);
                        room.devicenodes.Add(device);
                        break;
                }

                index += tlv.TLVLength;
            }

            return room;
        }

        /// <summary>
        /// 解析设备
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual DeviceNode ParseDevice(TLV message)
        {
            if (message.Tag != 0x121)
            {
                throw new TLVException(message, 0x121, message.Tag);
            }

            DeviceNode device = new DeviceNode();
            int index = 0;
            string content = message.Value;

            while (index < message.Length)
            {
                var tlv = ParseTLV(content, index);

                switch (tlv.Tag)
                {
                    case 0x123:
                        device.Name = tlv.Value;
                        break;
                    case 0x124:
                        device.Vendor = tlv.Value;
                        break;
                    case 0x125:
                        device.Type = tlv.Value;
                        break;
                    case 0x126:
                        device.Version = tlv.Value;
                        break;
                    case 0x127:
                        device.SerialNumber = tlv.Value;
                        break;
                    case 0x128:
                        device.HasStatus = 1;
                        device.Status = tlv;
                        break;
                    case 0x129:
                        device.Online = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x12B:
                        device.MainboardSerialNumber = tlv.Value;
                        break;
                    case 0x12C:
                        device.UserDeviceCode = tlv.Value;
                        break;
                    default:
                        throw new TLVException(tlv, "未知TLV类型");
                }

                index += tlv.TLVLength;
            }

            return device;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 解析响应
        /// </summary>
        /// <param name="message">响应报文</param>
        public abstract void ParseAck(string message);
        #endregion //Method

        #region Property
        /// <summary>
        /// 服务器操作结果
        /// </summary>
        public TLV ServerResult
        {
            get
            {
                return serverResult;
            }

            set
            {
                serverResult = value;
            }
        }
        #endregion //Property
    }
}
