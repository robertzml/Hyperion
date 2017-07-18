using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 注销报文
    /// 0x0B
    /// </summary>
    public class LogoutMessage : BaseMessage
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
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 注销报文
        /// </summary>
        /// <param name="accessType">接入类型</param>
        /// <param name="accessId">接入ID(用户名)</param>
        /// <param name="imei">IMEI</param>
        public LogoutMessage(int accessType, string accessId, string imei)
        {
            InitData(accessType, accessId, imei);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="accessType"></param>
        /// <param name="accessId"></param>
        /// <param name="imei"></param>
        private void InitData(int accessType, string accessId, string imei)
        {
            this.sequence = 1;
            this.infoCode = 0x0B;

            this.accessType = new TLV(tag: 0x08, value: accessType.ToString());
            this.accessId = new TLV(tag: 0x01, value: accessId);
            this.imei = new TLV(tag: 0x04, value: imei);
        }

        /// <summary>
        /// 生成消息报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            string msg = accessType.ToString() + accessId.ToString() + imei.ToString();
            return msg;
        }
        #endregion //Function
    }
}
