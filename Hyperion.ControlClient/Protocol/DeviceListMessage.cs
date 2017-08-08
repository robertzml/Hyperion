using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 用户设备列表查询报文
    /// 0x16
    /// </summary>
    public class DeviceListMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 接入类型 0x08
        /// </summary>
        private TLV accessType;

        /// <summary>
        /// 接入ID(用户名) 0x01
        /// </summary>
        private TLV accessId;

        /// <summary>
        /// IMEI 0x04
        /// </summary>
        private TLV imei;

        /// <summary>
        /// House序号 0x103
        /// </summary>
        private TLV houseNumber;

        /// <summary>
        /// Room序号 0x112
        /// </summary>
        private TLV roomNumber;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户设备列表查询报文
        /// </summary>
        /// <param name="accessType">接入类型</param>
        /// <param name="accessId">接入ID(用户名)</param>
        /// <param name="imei">IMEI</param>
        /// <param name="houseNumber">House序号</param>
        /// <param name="roomNumber">Room序号</param>
        public DeviceListMessage(int accessType, string accessId, string imei, int houseNumber, int roomNumber)
        {
            InitData(accessType, accessId, imei, houseNumber, roomNumber);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="accessType"></param>
        /// <param name="accessId"></param>
        /// <param name="imei"></param>
        /// <param name="houseNumber"></param>
        /// <param name="roomNumber"></param>
        private void InitData(int accessType, string accessId, string imei, int houseNumber, int roomNumber)
        {
            this.sequence = 1;
            this.infoCode = 0x16;

            this.accessType = new TLV(tag: 0x08, value: accessType.ToString());
            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.imei = new TLV(tag: 0x04, value: imei);
            this.houseNumber = new TLV(tag: 0x103, value: houseNumber.ToString("X"));
            this.roomNumber = new TLV(tag: 0x112, value: roomNumber.ToString("X"));
        }

        /// <summary>
        /// 生成消息报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            string msg = accessType.ToString() + accessId.ToString() + imei.ToString()
               + houseNumber.ToString() + roomNumber.ToString();
            return msg;
        }
        #endregion //Function
    }
}
