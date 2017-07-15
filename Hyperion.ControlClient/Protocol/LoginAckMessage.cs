using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    using Hyperion.ControlClient.Model;

    /// <summary>
    /// 登录响应报文
    /// </summary>
    public class LoginAckMessage : AckMessage
    {
        #region Field
        /// <summary>
        /// 用户Index
        /// </summary>
        private TLV userIndex;

        /// <summary>
        /// House数
        /// </summary>
        private TLV houseCount;

        /// <summary>
        /// House列表
        /// </summary>
        private List<LoginHouseNode> houses = new List<LoginHouseNode>();
        #endregion //Field

        #region Function
        protected override string GenerateInfoMessage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 解析House
        /// </summary>
        /// <param name="message">响应报文</param>
        /// <param name="count">House数量</param>
        private void ParseHouse(string message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                LoginHouseNode house = new LoginHouseNode();
                house.Rooms = new List<LoginRoomNode>();

                var des = ParseTLV(message, 0);
                if (des.Tag != 0x102)
                {
                    throw new TLVException(des, 0x102, des.Tag);
                }

                int index = 0;
                string content = des.Value;
                while (index < des.Length)
                {
                    var tlv = ParseTLV(content, index);

                    switch (tlv.Tag)
                    {
                        case 0x103:
                            house.Number = tlv;
                            break;
                        case 0x104:
                            house.Name = tlv;
                            break;
                        case 0x106:
                            house.Info = tlv;
                            break;
                        case 0x107:
                            house.Position = tlv;
                            break;
                        case 0x110:
                            house.RoomCount = tlv;
                            if (Convert.ToInt32(house.RoomCount.Value, 16) > 0)
                            {
                                var roomContent = content.Substring(index + tlv.TLVLength);
                                ParseRoom(roomContent, Convert.ToInt32(house.RoomCount.Value, 16), house.Rooms);
                                index += roomContent.Length;
                            }
                            break;
                    }

                    index += tlv.TLVLength;
                }

                houses.Add(house);
            }
        }

        /// <summary>
        /// 解析Room
        /// </summary>
        /// <param name="message">响应报文</param>
        /// <param name="count">Room数量</param>
        private void ParseRoom(string message, int count, List<LoginRoomNode> rooms)
        {
            for (int i = 0; i < count; i++)
            {
                LoginRoomNode room = new LoginRoomNode();
                room.Devices = new List<LoginDeviceNode>();

                var des = ParseTLV(message, 0);
                if (des.Tag != 0x111)
                {
                    throw new TLVException(des, 0x111, des.Tag);
                }

                string content = des.Value;
                int index = 0;
                while (index < des.Length)
                {
                    var tlv = ParseTLV(content, index);

                    switch (tlv.Tag)
                    {
                        case 0x112:
                            room.Number = tlv;
                            break;
                        case 0x113:
                            room.Name = tlv;
                            break;
                        case 0x114:
                            room.Type = tlv;
                            break;
                        case 0x120:
                            room.DeviceCount = tlv;
                            if (Convert.ToInt32(room.DeviceCount.Value, 16) > 0)
                            {
                                var deviceContent = content.Substring(index + tlv.TLVLength);
                                if (deviceContent.Length > 0)
                                {
                                    ParseDevice(deviceContent, Convert.ToInt32(room.DeviceCount.Value, 16), room.Devices);
                                    index += deviceContent.Length;
                                }
                            }
                            break;
                    }

                    index += tlv.TLVLength;
                }

                rooms.Add(room);
            }
        }

        /// <summary>
        /// 解析Device
        /// </summary>
        /// <param name="message">响应报文</param>
        /// <param name="count">Device数量</param>
        private void ParseDevice(string message, int count, List<LoginDeviceNode> devices)
        {
            for (int i = 0; i < count; i++)
            {
                LoginDeviceNode device = new LoginDeviceNode();

                var des = ParseTLV(message, 0);
                if (des.Tag != 0x121)
                {
                    throw new TLVException(des, 0x121, des.Tag);
                }

                int index = 0;
                while (index < des.Length)
                {
                    var tlv = ParseTLV(des.Value, index);

                    switch (tlv.Tag)
                    {
                        case 0x123:
                            device.Name = tlv;
                            break;
                        case 0x124:
                            device.Vendor = tlv;
                            break;
                        case 0x125:
                            device.Type = tlv;
                            break;
                        case 0x127:
                            device.SerialNumber = tlv;
                            break;
                        case 0x129:
                            device.Online = tlv;
                            break;
                    }

                    index += tlv.TLVLength;
                }

                devices.Add(device);
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 解析响应
        /// </summary>
        /// <param name="message">响应报文</param>
        public override void ParseAck(string message)
        {
            int messageLength = ParseHead(message);
            string content = message.Substring(this.version.Length + 16, messageLength);

            int index = 0;
            while (index < messageLength)
            {
                var tlv = ParseTLV(content, index);

                switch (tlv.Tag)
                {
                    case 0x13:
                        this.serverResult = tlv;
                        break;
                    case 0x019:
                        this.userIndex = tlv;
                        break;
                    case 0x101:
                        this.houseCount = tlv;
                        if (Convert.ToInt32(this.houseCount.Value, 16) > 0)
                        {
                            ParseHouse(content.Substring(index + tlv.TLVLength), Convert.ToInt32(this.houseCount.Value, 16));
                        }
                        break;
                }

                index += tlv.TLVLength;
            }
        }
        #endregion //Method
    }
}
