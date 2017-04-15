using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.BL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;

    /// <summary>
    /// 管理用户业务类
    /// </summary>
    public class UserInfoBusiness : AbstractBusiness<UserInfo, int>, IBaseBL<UserInfo, int>
    {
        #region Constructor
        /// <summary>
        /// 管理用户业务类
        /// </summary>
        public UserInfoBusiness()
        {
            this.baseDal = RepositoryFactory<IUserInfoRepository>.Instance;
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
            return this.baseDal.FindOneByField("username", username);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            var entity = this.baseDal.FindOneByField("username", username);
            if (entity == null)
                return false;

            if (entity.Password != password)
                return false;
            else
                return true;
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
            var entity = this.baseDal.FindById(id);

            if (entity.Password != oldPass)
                return false;

            entity.Password = newPass;
            return this.baseDal.Update(entity);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override bool Update(UserInfo entity)
        {
            var user = this.baseDal.FindById(entity.Id);
            user.Vendor = entity.Vendor;
            user.PhoneNumber = entity.PhoneNumber;
            user.Email = entity.Email;

            return base.Update(user);
        }
        #endregion //Method
    }
}
