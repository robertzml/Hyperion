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
    /// 设备状态类
    /// </summary>
    public class EquipmentState : IBaseEntity<long>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "Id")]
        public long Id { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Display(Name = "记录时间")]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// 开关状态
        /// </summary>
        [Display(Name = "开关状态")]
        public string SwitchState { get; set; }

        /// <summary>
        /// 累计加热时间
        /// </summary>
        [Display(Name = "累计加热时间")]
        public string HeatingTime { get; set; }

        /// <summary>
        /// 累计热水用量
        /// </summary>
        [Display(Name = "累计热水用量")]
        public string HotWater { get; set; }

        /// <summary>
        /// 累计通电时间
        /// </summary>
        [Display(Name = "累计通电时间")]
        public string DurationMachine { get; set; }

        /// <summary>
        /// 累计使用电量
        /// </summary>
        [Display(Name = "累计使用电量")]
        public string UseElectricity { get; set; }

        /// <summary>
        /// 累计节省电量
        /// </summary>
        [Display(Name = "累计节省电量")]
        public string PowerSaving { get; set; }
        #endregion //Property
    }
}
