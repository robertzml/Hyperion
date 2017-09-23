using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Hyperion.WebAPI.Models
{
    /// <summary>
    /// 注销响应模型
    /// </summary>
    [DataContract]
    public class LogoutModel
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
        /// 设备返回结果
        /// </summary>
        [DataMember(Name = "serverresult")]
        public int ServerResult { get; set; }
    }
}