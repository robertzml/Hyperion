using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 协议解析异常
    /// </summary>
    public class TLVException : Exception
    {
        #region Field
        /// <summary>
        /// 失败TLV
        /// </summary>
        private TLV tlv;
        #endregion //Field

        #region Constructor
        public TLVException(TLV tlv, int expectCode, int parseCode) : 
            base(string.Format("协议解析失败，预期类型:{0:X4}, 解出类型:{1:X4}", expectCode, parseCode))
        {
            this.tlv = tlv;            
        }

        public TLVException(TLV tlv, string message) :
            base(string.Format("协议解析失败, {0}", message))
        {
            this.tlv = tlv;
        }
        #endregion //Constructor
    }
}
