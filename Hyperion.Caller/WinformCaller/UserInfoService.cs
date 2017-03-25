using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    /// <summary>
    /// 管理用户访问服务类
    /// </summary>
    internal class UserInfoService : AbstractLocalService<UserInfo, int>, IUserInfoService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private UserInfoBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 管理用户访问服务类
        /// </summary>
        public UserInfoService() : base(BusinessFactory<UserInfoBusiness>.Instance)
        {
            this.bl = this.baseBL as UserInfoBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按用户名查找
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public UserInfo FindByUserName(string username)
        {
            return this.bl.FindByUserName(username);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return this.bl.Login(username, password);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="oldPass">原密码</param>
        /// <param name="newPass">新密码</param>
        /// <returns></returns>
        /// <remarks>
        /// 加密过程在客户端处理
        /// </remarks>
        public bool ChangePassword(int id, string oldPass, string newPass)
        {
            return this.bl.ChangePassword(id, oldPass, newPass);
        }
        #endregion //Method
    }
}
