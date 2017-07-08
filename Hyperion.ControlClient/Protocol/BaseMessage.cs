using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /* 
     * 协议格式说明：协议版本+流水号+报文内容
     * 报文内容说明：消息编码+长度+消息报文   (TLV)
     * 
     * 消息编码确定协议类型
     * 消息报文为多个TLV信元拼接
     * 
     */

    /// <summary>
    /// 基础协议报文类
    /// </summary>
    public abstract class BaseMessage
    {
        #region Field
        /// <summary>
        /// 协议版本
        /// </summary>
        protected readonly string version = "Homeconsole01.00";

        /// <summary>
        /// 流水号
        /// </summary>
        protected int sequence;

        /// <summary>
        /// 报文内容
        /// </summary>
        protected string messageContent;

        /// <summary>
        /// 消息编码
        /// </summary>
        protected int infoCode;

        /// <summary>
        /// 消息报文
        /// </summary>
        protected string infoMessage;
        #endregion //Field

        #region Function
        /// <summary>
        /// 生成报文内容
        /// </summary>
        /// <returns></returns>
        protected TLV GenerateMessageContent()
        {
            var mtlv = new TLV(tag: this.infoCode, value: infoMessage);
            return mtlv;
        }

        /// <summary>
        /// 生成消息报文
        /// </summary>
        /// <returns></returns>
        protected abstract void GenerateInfoMessage();

        /// <summary>
        /// 解析TLV
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="tlvLength">返回TLV长度</param>
        /// <returns></returns>
        protected TLV ParseTLV(string message, out int tlvLength)
        {
            int head = Convert.ToInt32(message.Substring(0, 4), 16);
            int length = Convert.ToInt32(message.Substring(4, 4), 16);
            string code = message.Substring(8, length);

            tlvLength = 8 + length;

            return new TLV(tag: head, value: code);
        }

        /// <summary>
        /// 解析TLV
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="pos">读取起始位置</param>
        /// <param name="tlvLength">返回TLV长度</param>
        /// <returns></returns>
        protected TLV ParseTLV(string message, int pos, out int tlvLength)
        {
            int head = Convert.ToInt32(message.Substring(pos, 4), 16);
            int length = Convert.ToInt32(message.Substring(pos + 4, 4), 16);
            string code = message.Substring(pos + 8, length);

            tlvLength = 8 + length;

            return new TLV(tag: head, value: code);
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 生成协议报文
        /// </summary>
        /// <returns></returns>
        public virtual string GetMessage()
        {
            GenerateInfoMessage();
            var mtlv = GenerateMessageContent();

            string message = this.version + this.sequence.ToString("X8") + mtlv.ToString();
            return message;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 协议版本
        /// </summary>
        public string Version
        {
            get
            {
                return version;
            }
        }

        /// <summary>
        /// 流水号
        /// </summary>
        public int Sequence
        {
            get
            {
                return sequence;
            }

            set
            {
                sequence = value;
            }
        }

        /// <summary>
        /// 消息编码
        /// </summary>
        public int InfoCode
        {
            get
            {
                return this.infoCode;
            }
            set
            {
                this.infoCode = value;
            }
        }
        #endregion //Property
    }
}
