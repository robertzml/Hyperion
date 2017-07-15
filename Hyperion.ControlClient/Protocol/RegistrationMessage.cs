using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 用户注册报文
    /// 0x01
    /// </summary>
    public class RegistrationMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 注册类型 0x00
        /// </summary>
        private TLV registerType;

        /// <summary>
        /// 接入ID(用户名) 0x01
        /// </summary>
        private TLV accessId;

        /// <summary>
        /// 用户ID 0x1B
        /// </summary>
        private TLV userId;

        /// <summary>
        /// 用户类型 0x07
        /// </summary>
        private TLV userType;

        /// <summary>
        /// IMEI 0x04
        /// </summary>
        private TLV imei;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户注册报文
        /// </summary>
        /// <param name="registerType">注册类型</param>
        /// <param name="accessId">接入ID(用户名)</param>
        /// <param name="userId">用户ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="imei">IMEI</param>
        public RegistrationMessage(int registerType, string accessId, long userId, int userType, string imei)
        {
            InitData(registerType, accessId, userId, userType, imei);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="registerType"></param>
        /// <param name="accessId"></param>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <param name="imei"></param>
        private void InitData(int registerType, string accessId, long userId, int userType, string imei)
        {
            this.sequence = 1;
            this.infoCode = 0x01;

            this.registerType = new TLV(tag: 0x00, value: registerType.ToString());
            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.userId = new TLV(tag: 0x1B, value: userId.ToString("X8"));
            this.userType = new TLV(tag: 0x07, value: userType.ToString());
            this.imei = new TLV(tag: 0x04, value: imei);
        }

        /// <summary>
        /// 生成消息报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            string msg = registerType.ToString() + accessId.ToString() + userId.ToString()
               + userType.ToString() + imei.ToString();
            return msg;
        }
        #endregion //Function
    }
}
