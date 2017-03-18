using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 房间类
    /// </summary>
    public class Room : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public virtual int Id { get; set; }

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
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 房间类型
        /// </summary>
        [Display(Name = "房间类型")]
        public Int16 RoomType { get; set; }
        #endregion //Property
    }
}
