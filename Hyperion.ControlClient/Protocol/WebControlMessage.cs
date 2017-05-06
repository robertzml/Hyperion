using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// Web端控制报文
    /// </summary>
    public class WebControlMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 接入类型
        /// </summary>
        private TLV accessType;

        /// <summary>
        /// 用户登录标识
        /// </summary>
        private TLV loginType;

        /// <summary>
        /// 用户ID
        /// </summary>
        private TLV userId;

        /// <summary>
        /// 设备序列号
        /// </summary>
        private TLV equipmentSerialNumber;

        /// <summary>
        /// 事务ID
        /// </summary>
        private TLV transactionId;

        /// <summary>
        /// 控制动作
        /// </summary>
        private TLV action;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// Web端控制报文
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="serialNumber">设备序列号</param>
        public WebControlMessage(string userId, string serialNumber)
        {
            InitData(userId, serialNumber);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="serialNumber"></param>
        private void InitData(string userId, string serialNumber)
        {
            this.sequence = 1;
            this.accessType = new TLV(tag: 0x06, value: "2");
            this.loginType = new TLV(tag: 0x34, value: "4");
            this.userId = new TLV(tag: 0x01, value: userId);
            this.equipmentSerialNumber = new TLV(tag: 0x127, value: serialNumber);
            this.transactionId = new TLV(tag: 0x1A, value: "1");
            this.action = new TLV(tag: 0x12, value: "000100010");
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 生成报文
        /// </summary>
        /// <returns></returns>
        public override string GetMessage()
        {
            string message = this.version + this.sequence.ToString("X8") + accessType.ToString() + loginType.ToString() + userId.ToString()
                + equipmentSerialNumber.ToString() + transactionId.ToString() + action.ToString();

            return message;
        }
        #endregion //Method
    }
}
