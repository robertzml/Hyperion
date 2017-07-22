using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 设备相关操作报文
    /// 0x07
    /// </summary>
    public class UnifiedMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 接入类型 0x08
        /// </summary>
        private TLV accessType;

        /// <summary>
        /// 接入ID(用户名)  0x01
        /// </summary>
        private TLV accessId;

        /// <summary>
        /// IMEI 0x04
        /// </summary>
        private TLV imei;

        /// <summary>
        /// 统一操作码 0x09
        /// </summary>
        private TLV unifiedCode;

        /// <summary>
        /// House序号 0x103
        /// </summary>
        private TLV houseNumber;

        /// <summary>
        /// House名称 0x104
        /// </summary>
        private TLV houseName;

        /// <summary>
        /// House信息 0x106
        /// </summary>
        private TLV houseInfo;

        /// <summary>
        /// House位置 0x107
        /// </summary>
        private TLV housePosition;

        /// <summary>
        /// Room序号 0x112
        /// </summary>
        private TLV roomNumber;

        /// <summary>
        /// Room名称 0x113
        /// </summary>
        private TLV roomName;

        /// <summary>
        /// Room类型 0x114
        /// </summary>
        private TLV roomType;

        /// <summary>
        /// Device名称 0x123
        /// </summary>
        private TLV deviceName;

        /// <summary>
        /// Deivce类型 0x125
        /// </summary>
        private TLV deviceType;

        /// <summary>
        /// Device序列号 0x127
        /// </summary>
        private TLV serialNumber;

        /// <summary>
        /// 验证码 0x10
        /// </summary>
        private TLV verifyCode;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 增加设备
        /// </summary>
        /// <param name="accessId"></param>
        /// <param name="imei"></param>
        /// <param name="houseNumber"></param>
        /// <param name="roomNumber"></param>
        /// <param name="deviceName"></param>
        /// <param name="deviceType"></param>
        /// <param name="serialNumber"></param>
        public UnifiedMessage(string accessId, string imei, int houseNumber, int roomNumber, string deviceName, string deviceType, string serialNumber)
        {
            this.sequence = 1;
            this.infoCode = 0x07;
            this.unifiedCode = new TLV(tag: 0x09, value: "6");

            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.imei = new TLV(tag: 0x04, value: imei);
            this.houseNumber = new TLV(tag: 0x103, value: houseNumber.ToString("X"));
            this.roomNumber = new TLV(tag: 0x112, value: roomNumber.ToString("X"));
            this.deviceName = new TLV(tag: 0x123, value: deviceName);
            this.deviceType = new TLV(tag: 0x125, value: deviceType);
            this.serialNumber = new TLV(tag: 0x127, value: serialNumber);
        }

        /// <summary>
        /// 修改设备
        /// </summary>
        /// <param name="accessId"></param>
        /// <param name="imei"></param>
        /// <param name="deviceName"></param>
        /// <param name="serialNumber"></param>
        public UnifiedMessage(string accessId, string imei, string deviceName, string serialNumber)
        {
            this.sequence = 1;
            this.infoCode = 0x07;
            this.unifiedCode = new TLV(tag: 0x09, value: "7");

            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.imei = new TLV(tag: 0x04, value: imei);
            this.deviceName = new TLV(tag: 0x123, value: deviceName);
            this.serialNumber = new TLV(tag: 0x127, value: serialNumber);
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="accessId"></param>
        /// <param name="imei"></param>
        /// <param name="serialNumber"></param>
        public UnifiedMessage(string accessId, string imei, string serialNumber)
        {
            this.sequence = 1;
            this.infoCode = 0x07;
            this.unifiedCode = new TLV(tag: 0x09, value: "8");

            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.imei = new TLV(tag: 0x04, value: imei);
            this.serialNumber = new TLV(tag: 0x127, value: serialNumber);
        }
        #endregion //Constructor


        #region Method
        /// <summary>
        /// 生成消息报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            string msg = "";
            switch (Convert.ToInt32(this.unifiedCode.Value, 16))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    msg = accessId.ToString() + imei.ToString() + unifiedCode.ToString() + houseNumber.ToString() + roomNumber.ToString() +
                        deviceName.ToString() + deviceType.ToString() + serialNumber.ToString();
                    break;
                case 7:
                    msg = accessId.ToString() + imei.ToString() + unifiedCode.ToString() +
                        deviceName.ToString() + serialNumber.ToString();
                    break;
                case 8:
                    msg = accessId.ToString() + imei.ToString() + unifiedCode.ToString() + serialNumber.ToString();
                    break;
            }

            return msg;
        }
        #endregion //Method
    }
}
