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
        #endregion //Field

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
        #endregion //Property
    }
}
