using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.ControlClient.Model
{
    /// <summary>
    /// 登录响应信元
    /// </summary>
    public class LoginNode
    {
        /// <summary>
        /// 设备返回结果
        /// </summary>
        public int serverresult { get; set; }

        /// <summary>
        /// 用户Index 0x19
        /// </summary>
        public int userindex { get; set; }

        /// <summary>
        /// House数 0x101
        /// </summary>
        public int housecount { get; set; }

        /// <summary>
        /// House信息 0x102
        /// </summary>
        public List<HouseNode> housenodes { get; set; }
    }
}
