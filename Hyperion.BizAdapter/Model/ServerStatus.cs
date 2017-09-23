using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Model
{
    /// <summary>
    /// 业务状态结果
    /// </summary>
    public class ServerStatus
    {
        /// <summary>
        /// 业务返回结果
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 业务消息
        /// </summary>
        public string message { get; set; }
    }
}
