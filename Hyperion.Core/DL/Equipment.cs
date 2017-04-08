using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 设备类
    /// </summary>
    /// <remarks>
    /// 设备用户映射，多对多
    /// </remarks>
    public class Equipment : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 房屋ID
        /// </summary>
        [Display(Name = "房屋ID")]
        public int HomeId { get; set; }

        /// <summary>
        /// 房间ID
        /// </summary>
        [Display(Name = "房间ID")]
        public int RoomId { get; set; }

        /// <summary>
        /// ID，非主键
        /// </summary>
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }
        #endregion //Property
    }
}
