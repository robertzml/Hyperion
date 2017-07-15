using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 登录响应设备信元
    /// </summary>
    public class LoginDeviceNode
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public TLV Name { get; set; }

        /// <summary>
        /// 设备厂商
        /// </summary>
        public TLV Vendor { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public TLV Type { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        public TLV Model { get; set; }

        /// <summary>
        /// 设备序列号
        /// </summary>
        public TLV SerialNumber { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public TLV Status { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public TLV Online { get; set; }
    }
}
