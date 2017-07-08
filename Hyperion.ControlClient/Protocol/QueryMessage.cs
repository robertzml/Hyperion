using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Protocol
{
    /// <summary>
    /// 查询报文
    /// </summary>
    public class QueryMessage : BaseMessage
    {
        #region Field
        /// <summary>
        /// 接入类型
        /// </summary>
        private TLV accessType;

        /// <summary>
        /// 用户ID
        /// </summary>
        private TLV userId;

        /// <summary>
        /// 超时设置
        /// </summary>
        private TLV timeOut;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 查询报文
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="seq">序列号</param>
        public QueryMessage(string userId, int seq = 1)
        {
            InitData(userId, seq);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="userId"></param>
        private void InitData(string userId, int seq)
        {
            this.sequence = seq;
            this.infoCode = 0x10;
            this.accessType = new TLV(tag: 0x06, value: "2");
            this.userId = new TLV(tag: 0x01, value: userId);
            this.timeOut = new TLV(tag: 0x15, value: "f");
        }

        /// <summary>
        /// 生成信元报文
        /// </summary>
        /// <returns></returns>
        protected override string GenerateInfoMessage()
        {
            string msg = accessType.ToString() + userId.ToString() + timeOut.ToString();
            return msg;
        }
        #endregion //Function

        #region Method
        #endregion //Method
    }
}
