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
    /// 用户设备表
    /// </summary>
    public class UserEquipment : IBaseEntity<long>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public long Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public long UserId { get; set; }

        /// <summary>
        /// 房屋ID
        /// </summary>
        [Display(Name = "房屋ID")]
        public long HomeId { get; set; }

        /// <summary>
        /// 房间ID
        /// </summary>
        [Display(Name = "房间ID")]
        public long RoomId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 设备名
        /// </summary>
        [Display(Name = "设备名")]
        public string DeviceName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateDate { get; set; }
        #endregion //Property
    }
}
