using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// Web控制响应消息
    /// </summary>
    public class WebControlAckMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 用户ID
        /// </summary>
        private TLV userId;

        /// <summary>
        /// 设备序列号
        /// </summary>
        private TLV equipmentSerialNumber;

        /// <summary>
        /// 服务器操作结果
        /// </summary>
        private TLV serverResult;
        #endregion //Field

        #region Function
        /// <summary>
        /// 生成信元报文
        /// </summary>
        /// <returns></returns>
        protected override void GenerateInfoMessage()
        {
            throw new NotImplementedException();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 解析响应
        /// </summary>
        /// <param name="message">响应报文</param>
        public void ParseAck(string message)
        {
            var ackVersion = message.Substring(0, this.version.Length);
            this.sequence = Convert.ToInt32(message.Substring(this.version.Length, 8), 16);

            var messageHead = message.Substring(this.version.Length + 8, 8);

            int messageLength = Convert.ToInt32(messageHead.Substring(4, 4), 16);
            var messageContent = message.Substring(this.version.Length + 16, messageLength);

            int length = 0;
            int index;
            this.serverResult = ParseTLV(messageContent, out index);
            length += index;
            this.userId = ParseTLV(messageContent.Substring(length), out index);
            length += index;
            this.equipmentSerialNumber = ParseTLV(messageContent.Substring(length), out index);
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 用户ID
        /// </summary>
        public TLV UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

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

        /// <summary>
        /// 设备序列号
        /// </summary>
        public TLV EquipmentSerialNumber
        {
            get
            {
                return equipmentSerialNumber;
            }

            set
            {
                equipmentSerialNumber = value;
            }
        }
        #endregion //Property
    }
}
