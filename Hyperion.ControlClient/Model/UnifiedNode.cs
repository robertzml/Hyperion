using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 统一操作结果信元
    /// </summary>
    public class UnifiedNode
    {
        /// <summary>
        /// 统一操作码 0x09
        /// </summary>
        public int UnifiedCode { get; set; }

        // <summary>
        /// House序号 0x103
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// Room序号 0x112
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// 设备厂商 0x124
        /// </summary>
        public string Vendor { get; set; }

        /// <summary>
        /// 设备类型 0x125
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 设备版本 0x126
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 设备序列号 0x127
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 设备状态 0x128
        /// </summary>
        public TLV Status { get; set; }

        /// <summary>
        /// 在线状态 0x129
        /// </summary>
        public int Online { get; set; }
    }
}
