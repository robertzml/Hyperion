using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 注册响应报文
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
            int messageLength = ParseHead(message);
            string content = message.Substring(this.version.Length + 16, messageLength);

            int length = 0;
            int index = 0;
            while (index < messageLength)
            {
                var tlv = ParseTLV(content, index, out length);

                switch (tlv.Tag)
                {
                    case 0x13:
                        this.serverResult = tlv;
                        break;
                }

                index += length;
            }
        }
        #endregion //Method
    }
}
