using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 登录响应房屋信元
    /// </summary>
    public class LoginRoomNode
    {
        /// <summary>
        /// Room序号
        /// </summary>
        public TLV Number { get; set; }

        /// <summary>
        /// Room名称
        /// </summary>
        public TLV Name { get; set; }
        
        /// <summary>
        /// Room类型
        /// </summary>
        public TLV Type { get; set; }

        /// <summary>
        /// Device数量
        /// </summary>
        public TLV DeviceCount { get; set; }

        /// <summary>
        /// Device信元
        /// </summary>
        public List<LoginDeviceNode> Devices { get; set; }
    }
}
