using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hyperion.WebAPI.Utility
{
    /// <summary>
    /// HTTP错误消息
    /// </summary>
    public enum HttpErrorMessage
    {
        /// <summary>
        /// 错误请求
        /// </summary>
        [Display(Name = "错误请求")]
        BadRequest = 1,

        /// <summary>
        /// 认证失败
        /// </summary>
        [Display(Name = "认证失败")]
        AuthFailed = 2
    }
}