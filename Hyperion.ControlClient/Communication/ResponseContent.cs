using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Communication
{
    /// <summary>
    /// HTTP返回响应
    /// </summary>
    public class ResponseContent
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string ResponseMessage { get; set; }
    }
}
