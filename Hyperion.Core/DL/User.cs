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
    /// 用户表
    /// </summary>
    public class User : IBaseEntity<long>
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
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [Display(Name = "用户类型")]
        public short UserType { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
        [Display(Name = "IMEI")]
        public string IMEI { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        [Display(Name = "在线状态")]
        public short LoginState { get; set; }
        #endregion //Property
    }
}
