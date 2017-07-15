using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 登录报文
    /// 0x03
    /// </summary>
    public class LoginMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 接入ID(用户名)  0x01
        /// </summary>
        private TLV accessId;

        /// <summary>
        /// 用户ID  0x1B
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

        /// <summary>
        /// 用户登录标识区分  0x1A
        /// </summary>
        private TLV userLoginType;

        /// <summary>
        /// 取得设备列表及状态标志 0x1C
        /// </summary>
        private TLV getStatus;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 登录报文
        /// </summary>
        /// <param name="accessId">接入ID(用户名)</param>
        /// <param name="userId">用户ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="imei">IMEI</param>
        /// <param name="userLoginType">用户登录标识区分</param>
        /// <param name="getStatus">取得设备列表及状态标志</param>
        public LoginMessage(string accessId, long userId, int userType, string imei, int userLoginType, int getStatus)
        {
            InitData(accessId, userId, userType, imei, userLoginType, getStatus);
        }
        #endregion //Constructor

        #region Function
        private void InitData(string accessId, long userId, int userType, string imei, int userLoginType, int getStatus)
        {
            this.sequence = 1;
            this.infoCode = 0x03;

            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.userId = new TLV(tag: 0x1B, value: userId.ToString("X8"));
            this.userType = new TLV(tag: 0x07, value: userType.ToString());
            this.imei = new TLV(tag: 0x04, value: imei);
            this.userLoginType = new TLV(tag: 0x1A, value: userLoginType.ToString());
            this.getStatus = new TLV(tag: 0x1C, value: getStatus.ToString());
        }

        /// <summary>
        /// 生成消息报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            string msg = accessId.ToString() + userId.ToString() + userType.ToString() + imei.ToString() +
                userLoginType.ToString() + getStatus.ToString();
            return msg;
        }
        #endregion //Function
    }
}
