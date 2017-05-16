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
        #endregion //Field

        #region Function
        /// <summary>
        /// 生成消息编码
        /// </summary>
        /// <param name="cell">信元内容</param>
        /// <returns></returns>
        protected TLV GenerateMessageCode(string cell)
        {
            var mtlv = new TLV(tag: this.messageCode, value: cell);
            return mtlv;
        }

        /// <summary>
        /// 生成信元报文
        /// </summary>
        /// <returns></returns>
        protected abstract string GenerateCellMessage();
        #endregion //Function

        #region Method
        /// <summary>
        /// 生成报文
        /// </summary>
        /// <returns></returns>
        public abstract string GetMessage();
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
