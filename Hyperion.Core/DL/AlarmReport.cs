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
    /// 故障消息类
    /// </summary>
    public class AlarmReport : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户Id")]
        public int? UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 故障代码
        /// </summary>
        [Display(Name = "故障代码")]
        public string AlarmCode { get; set; }

        /// <summary>
        /// 故障说明
        /// </summary>
        [Display(Name = "故障说明")]
        public string AlarmDescription { get; set; }

        /// <summary>
        /// 终端号码
        /// </summary>
        [Display(Name = "终端号码")]
        public string MSISDN { get; set; }

        /// <summary>
        /// 故障状态
        /// </summary>
        [Display(Name = "故障状态")]
        public int? DealStatus { get; set; }

        /// <summary>
        /// 申报时间
        /// </summary>
        [Display(Name = "申报时间")]
        public DateTime? CreateDate { get; set; }
        #endregion //Property
    }
}
