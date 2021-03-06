﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    /// <summary>
    /// 房间信元
    /// </summary>
    public class RoomNode
    {
        /// <summary>
        /// Room序号 0x112
        /// </summary>
        public int number { get; set; }

        /// <summary>
        /// Room名称 0x113
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Room类型 0x114
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// Device数量 0x120
        /// </summary>
        public int devicecount { get; set; }

        /// <summary>
        /// Device信元 0x121
        /// </summary>
        public List<DeviceNode> devicenodes { get; set; }
    }
}
