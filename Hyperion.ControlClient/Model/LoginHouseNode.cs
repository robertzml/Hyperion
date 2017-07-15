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
    public class LoginHouseNode
    {
        /// <summary>
        /// House序号
        /// </summary>
        public TLV Number { get; set; }

        /// <summary>
        /// House名称
        /// </summary>
        public TLV Name { get; set; }

        /// <summary>
        /// House信息
        /// </summary>
        public TLV Info { get; set; }

        /// <summary>
        /// House位置
        /// </summary>
        public TLV Position { get; set; }

        /// <summary>
        /// Room数量
        /// </summary>
        public TLV RoomCount { get; set; }

        /// <summary>
        /// Room信元
        /// </summary>
        public List<LoginRoomNode> Rooms { get; set; }
    }
}
