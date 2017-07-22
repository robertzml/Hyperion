using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    using Hyperion.ControlClient.Model;

    /// <summary>
    /// 设备相关操作响应报文
    /// 0x08
    /// </summary>
    public class UnifiedAckMessage : AckMessage
    {
        #region Field
        /// <summary>
        /// 操作响应信元
        /// </summary>
        private UnifiedNode unifiedNode;
        #endregion //Field

        #region Constructor
        public UnifiedAckMessage()
        {
            this.unifiedNode = new UnifiedNode();
        }
        #endregion //Constructor

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

            if (this.messageContent.Tag != 0x08)
            {
                throw new TLVException(messageContent, 0x08, messageContent.Tag);
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
                    case 0x09:
                        unifiedNode.UnifiedCode = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x103:
                        unifiedNode.HouseNumber = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x112:
                        unifiedNode.RoomNumber = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x124:
                        unifiedNode.Vendor = tlv.Value;
                        break;
                    case 0x125:
                        unifiedNode.Type = tlv.Value;
                        break;
                    case 0x126:
                        unifiedNode.Version = tlv.Value;
                        break;
                    case 0x127:
                        unifiedNode.SerialNumber = tlv.Value;
                        break;
                    case 0x128:
                        unifiedNode.Status = tlv;
                        break;
                    case 0x129:
                        unifiedNode.Online = Convert.ToInt32(tlv.Value, 16);
                        break;
                    default:
                        throw new TLVException(tlv, "未知TLV类型");
                }

                index += tlv.TLVLength;
            }
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 操作响应信元
        /// </summary>
        public UnifiedNode UnifiedNode
        {
            get
            {
                return unifiedNode;
            }
        }
        #endregion //Property
    }
}
