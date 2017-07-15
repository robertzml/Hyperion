using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
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
