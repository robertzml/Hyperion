using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 查询响应报文
    /// </summary>
    public class AnswerMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 用户ID
        /// </summary>
        private TLV userId;

        /// <summary>
        /// 服务器操作结果
        /// </summary>
        private TLV serverResult;
        #endregion //Field

        #region Function
        protected override string GenerateInfoMessage()
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

            int length;
            int index = 0;
            while (index < messageLength)
            {
                var tlv = ParseTLV(messageContent, index, out length);

                switch (tlv.Tag)
                {
                    case 0x13:
                        this.serverResult = tlv;
                        break;
                    case 0x01:
                        this.userId = tlv;
                        break;
                }

                index += length;
            }
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
        #endregion //Property
    }
}
