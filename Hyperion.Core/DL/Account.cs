using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 用户类
    /// </summary>
    public class Account : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 登录状态
        /// </summary>
        [Display(Name = "登录状态")]
        public short LoginState { get; set; }

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
        /// 操作系统类型
        /// </summary>
        [Display(Name = "操作系统类型")]
        public Int16? OSType { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [Display(Name = "编辑时间")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateDate { get; set; }
        #endregion //Property
    }
}
