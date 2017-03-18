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
    public class OperateRecord : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        [Display(Name = "日志类型")]
        public short LogType { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        [Display(Name = "日志时间")]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作类型")]
        public short OpType { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// IMSI
        /// </summary>
        [Display(Name = "IMSI")]
        public string IMSI { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
        [Display(Name = "IMEI")]
        public string IMEI { get; set; }

        /// <summary>
        /// MSISDN
        /// </summary>
        [Display(Name = "MSISDN")]
        public string MSISDN { get; set; }

        /// <summary>
        /// 系统类型
        /// </summary>
        [Display(Name = "系统类型")]
        public Int16? OSType { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 请求动作
        /// </summary>
        [Display(Name = "请求动作")]
        public string RequestBody { get; set; }
        #endregion //Property
    }
}
