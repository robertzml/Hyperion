using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyperion.WebAPI.Models
{
    /// <summary>
    /// 注销响应模型
    /// </summary>
    public class LogoutModel
    {
        /// <summary>
        /// 业务返回结果
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 业务消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 设备返回结果
        /// </summary>
        public int ServerResult { get; set; }
    }
}