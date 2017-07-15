using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 注册响应报文
    /// 0x02
    /// </summary>
    public class RegistrationAckMessage : AckMessage
    {
        #region Function
        /// <summary>
        /// 生成信元报文
        /// </summary>
        /// <returns></returns>
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
        public override void ParseAck(string message)
        {
            ParseMessageContent(message);

            if (this.messageContent.Tag != 0x02)
            {
                throw new TLVException(messageContent, 0x02, messageContent.Tag);
            }

            int index = 0;
            string content = messageContent.Value;
            while (index < messageContent.Length)
            {
                var tlv = ParseTLV(content, index);

                switch (tlv.Tag)
                {
                    case 0x13:
                        this.serverResult = tlv;
                        break;
                    default:
                        throw new TLVException(tlv, "未知TLV类型");
                }

                index += tlv.TLVLength;
            }
        }
        #endregion //Method
    }
}
