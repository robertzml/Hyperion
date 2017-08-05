using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    /// <summary>
    /// 注册响应信元
    /// </summary>
    public class RegistrationNode
    {
        /// <summary>
        /// 设备返回结果
        /// </summary>
        public int ServerResult { get; set; }

        /// <summary>
        /// 用户内部INDEX 0x19
        /// </summary>
        public long UserIndex { get; set; }
    }
}
