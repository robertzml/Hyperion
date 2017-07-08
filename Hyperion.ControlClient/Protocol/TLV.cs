using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// TLV信元类
    /// </summary>
    public class TLV
    {
        #region Field
        /// <summary>
        /// Tag
        /// </summary>
        private int tag;

        /// <summary>
        /// 长度
        /// </summary>
        private int length;

        /// <summary>
        /// 信元内容
        /// </summary>
        private string value;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// TLV信元类
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <param name="value">信元内容</param>
        public TLV(int tag, string value)
        {
            this.tag = tag;
            this.value = value;
            this.length = value.Length;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 信元编码
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string msg = tag.ToString("X4") + length.ToString("X4") + value.ToString();
            return msg;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// Tag
        /// </summary>
        public int Tag
        {
            get
            {
                return this.tag;
            }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length
        {
            get
            {
                return this.length;
            }
        }

        /// <summary>
        /// 信元内容
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }
        #endregion //Property
    }
}
