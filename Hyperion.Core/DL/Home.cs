using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 房屋类
    /// </summary>
    public class Home : IBaseEntity<int>
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
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [Display(Name = "信息")]
        public string Info { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [Display(Name = "位置")]
        public string Position { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [Display(Name = "纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Display(Name = "经度")]
        public string Longitude { get; set; }
        #endregion //Property
    }
}
