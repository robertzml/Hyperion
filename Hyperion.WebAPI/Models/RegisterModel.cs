using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyperion.WebAPI.Models
{
    /// <summary>
    /// 注册响应模型
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// 业务返回结果
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 业务消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 设备返回结果
        /// </summary>
        public int serverresult { get; set; }
    }
}