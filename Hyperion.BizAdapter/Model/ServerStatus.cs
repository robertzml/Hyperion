using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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

    /// <summary>
    /// 业务状态结果2
    /// </summary>
    [DataContract]
    public class ServerStatus2
    {
        /// <summary>
        /// 业务返回结果
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// 业务消息
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// 是否设备主人
        /// </summary>
        [DataMember(Name = "isowner")]
        public int IsOwner { get; set; }
    }
}
