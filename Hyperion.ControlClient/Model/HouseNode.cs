using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    /// <summary>
    /// 房屋信元
    /// </summary>
    public class HouseNode
    {
        #region Constructor
        public HouseNode()
        {
            this.Name = "";
            this.Info = "";
            this.Position = "";
        }
        #endregion //Constructor

        #region Property
        /// <summary>
        /// House序号 0x103
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// House名称 0x104
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// House信息 0x106
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// House位置 0x107
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Room数量 0x110
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        /// Room信元 0x111
        /// </summary>
        public List<RoomNode> RoomNodes { get; set; }
        #endregion //Property
    }
}
