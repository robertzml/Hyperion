using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    /// <summary>
    /// 用户设备列表信元
    /// </summary>
    public class DeviceListNode
    {
        /// <summary>
        /// 设备返回结果
        /// </summary>
        public int ServerResult { get; set; }

        /// <summary>
        /// 接入ID(用户名) 0x01
        /// </summary>
        public string AccessId { get; set; }

        /// <summary>
        /// House序号 0x103
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// Room序号 0x112
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// Device数 0x120 
        /// </summary>
        public int DeviceCount { get; set; }

        /// <summary>
        /// Device 信息
        /// </summary>
        public List<DeviceNode> DeviceNodes;
    }
}
