using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 基础报文类
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
        /// 消息编码
        /// </summary>
        protected int messageCode;

        /// <summary>
        /// 信元报文
        /// </summary>
        protected string cellMessage;
        #endregion //Field

        #region Function
        /// <summary>
        /// 生成消息编码
        /// </summary>
        /// <returns></returns>
        protected TLV GenerateMessageCode()
        {
            var mtlv = new TLV(tag: this.messageCode, value: cellMessage);
            return mtlv;
        }

        /// <summary>
        /// 生成信元报文
        /// </summary>
        /// <returns></returns>
        protected abstract void GenerateCellMessage();

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
        #endregion //Function

        #region Method
        /// <summary>
        /// 生成报文
        /// </summary>
        /// <returns></returns>
        public virtual string GetMessage()
        {
            GenerateCellMessage();
            var mtlv = GenerateMessageCode();

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
        public int MessageCode
        {
            get
            {
                return this.messageCode;
            }
            set
            {
                this.messageCode = value;
            }
        }
        #endregion //Property
    }
}
