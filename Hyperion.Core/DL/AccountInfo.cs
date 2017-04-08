using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.DL
{
    using Poseidon.Base.Framework;

    public class AccountInfo : IBaseEntity<int>
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
        /// 身份证号
        /// </summary>
        [Display(Name = "身份证号")]
        public string IDCard { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Display(Name = "生日")]
        public string Birthday { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name = "真实姓名")]
        public string RealUserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public Int16? Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄")]
        public Int16? Age { get; set; }

        /// <summary>
        /// 星座
        /// </summary>
        [Display(Name = "星座")]
        public string Horoscope { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [Display(Name = "身高")]
        public Int16? Height { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        [Display(Name = "体重")]
        public Int16? Weight { get; set; }

        /// <summary>
        /// 家庭地址
        /// </summary>
        [Display(Name = "家庭地址")]
        public string FamilyAddress { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [Display(Name = "职业")]
        public string Profession { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [Display(Name = "公司")]
        public string Company { get; set; }

        /// <summary>
        /// 备用电话
        /// </summary>
        [Display(Name = "备用电话")]
        public string ReservePhoneNo { get; set; }

        /// <summary>
        /// 备用Email
        /// </summary>
        [Display(Name = "备用Email")]
        public string ReserveEmail { get; set; }
        #endregion //Property
    }
}
