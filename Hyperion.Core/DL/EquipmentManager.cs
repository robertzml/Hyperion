using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 设备管理类
    /// </summary>
    public class EquipmentManager : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Required]
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        [Required]
        [Display(Name = "厂家")]
        public string Vendor { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [Display(Name = "设备类型")]
        public string Type { get; set; }

        /// <summary>
        /// 设备版本
        /// </summary>
        [Display(Name = "设备版本")]
        public string Version { get; set; }

        /// <summary>
        /// 升级版本
        /// </summary>
        [Display(Name = "升级版本")]
        public string UpgradeVersion { get; set; }

        /// <summary>
        /// 所有者
        /// </summary>
        [Display(Name = "所有者")]
        public string Owner { get; set; }

        /// <summary>
        /// 所有者电话
        /// </summary>
        [Display(Name = "所有者电话")]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public Int16? State { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        [Display(Name = "录入时间")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [Display(Name = "编辑时间")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 录入者
        /// </summary>
        [Display(Name = "录入者")]
        public string UserName { get; set; }
        #endregion //Property
    }
}
