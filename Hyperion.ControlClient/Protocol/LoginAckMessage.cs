using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    using Hyperion.ControlClient.Model;

    /// <summary>
    /// 登录响应报文
    /// 0x04
    /// </summary>
    public class LoginAckMessage : AckMessage
    {
        #region Field
        /// <summary>
        /// 登录信元
        /// </summary>
        private LoginNode loginNode;
        #endregion //Field

        #region Constructor
        public LoginAckMessage()
        {
            this.loginNode = new LoginNode();
            loginNode.HouseNodes = new List<HouseNode>();
        }
        #endregion //Constructor

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
        public override void ParseAck(string message)
        {
            ParseMessageContent(message);

            if (this.messageContent.Tag != 0x04)
            {
                throw new TLVException(messageContent, 0x04, messageContent.Tag);
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
                        loginNode.ServerResult = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x019:
                        loginNode.UserIndex = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x101:
                        loginNode.HouseCount = Convert.ToInt32(tlv.Value, 16);
                        break;
                    case 0x102:
                        var house = ParseHouse(tlv);
                        loginNode.HouseNodes.Add(house);
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
        /// 登录响应信息
        /// </summary>
        public LoginNode LoginNode
        {
            get
            {
                return loginNode;
            }
        }
        #endregion //Property
    }
}
