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
    /// 版本升级类
    /// </summary>
    public class UpgradeVersion : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID，不使用
        /// </summary>
        [Display(Name = "Id")]
        public virtual int Id { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        [Display(Name = "文件名")]
        public string File { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [Display(Name = "版本")]
        public Int16 Version { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        [Display(Name = "更新日期")]
        public DateTime UpgradeTime { get; set; }
        #endregion //Property
    }
}
