using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.BizAdapter.Model
{
    /// <summary>
    /// 登录结果
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int userid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string picture { get; set; }

        /// <summary>
        /// 钱包ID
        /// </summary>
        public string walletid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// 自动扣款
        /// </summary>
        public string auto_chargeback { get; set; }
    }
}
