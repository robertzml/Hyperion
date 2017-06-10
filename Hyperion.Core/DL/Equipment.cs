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
    public class Equipment : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Required]
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 控制器型号
        /// </summary>
        [Display(Name = "控制器型号")]
        public string ControllerModel { get; set; }

        /// <summary>
        /// 软件版本
        /// </summary>
        [Display(Name = "软件版本")]
        public string Version { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        [Display(Name = "设备型号")]
        public string EquipmentModel { get; set; }

        /// <summary>
        /// 厂家代码
        /// </summary>
        [Required]
        [Display(Name = "厂家代码")]
        public string Vendor { get; set; }

        /// <summary>
        /// 初始时间
        /// </summary>
        [Display(Name = "初始时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}
