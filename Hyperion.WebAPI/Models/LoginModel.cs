using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyperion.WebAPI.Models
{
    using Hyperion.BizAdapter.Model;
    using Hyperion.ControlClient.Model;

    /// <summary>
    /// 登录返回结果
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 业务服务状态
        /// </summary>
        public ServerStatus BizStatus { get; set; }

        /// <summary>
        /// 业务返回对象
        /// </summary>
        public LoginResult LoginResult { get; set; }

        /// <summary>
        /// 设备返回对象
        /// </summary>
        public LoginNode LoginNode { get; set; }
    }
}