using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 操作日志类
    /// </summary>
    public class OperateRecord : IBaseEntity<long>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "Id")]
        public long Id { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        [Display(Name = "日志类型")]
        public int LogType { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        [Display(Name = "日志时间")]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作类型")]
        public int OpType { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 操作来源
        /// </summary>
        [Display(Name = "操作来源")]
        public int OpSource { get; set; }

        /// <summary>
        /// 操作用户
        /// </summary>
        [Display(Name = "操作用户")]
        public string OpUser { get; set; }

        /// <summary>
        /// 操作标识
        /// </summary>
        [Display(Name = "操作标识")]
        public string OpIdentity { get; set; }

        /// <summary>
        /// 报文内容
        /// </summary>
        [Display(Name = "报文内容")]
        public string RequestBody { get; set; }
        #endregion //Property
    }
}
