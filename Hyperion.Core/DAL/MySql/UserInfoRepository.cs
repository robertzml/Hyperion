using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.DAL.MySQL
{
    using MySql.Data.MySqlClient;
    using Poseidon.Base.System;
    using Poseidon.Data;
    using Hyperion.Core.Abstract;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;
    using System.Data;

    /// <summary>
    /// 管理用户数据访问类
    /// </summary>
    internal class UserInfoRepository : AbstractDALMySql<UserInfo>, IUserInfoRepository
    {
        #region Constructor
        public UserInfoRepository() : base("user_info", "id")
        {
            base.Init(ConnectionSource.Cache, "ConnectionString");
        }
        #endregion //Constructor

        #region Function
        protected override UserInfo DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override UserInfo DataRowToEntity(DataRow row)
        {
            UserInfo entity = new UserInfo();
            entity.Id = Convert.ToInt32(row["id"]);
            entity.UserName = row["username"].ToString();
            entity.Password = row["password"].ToString();
            entity.UserLevel = Convert.ToInt32(row["userlevel"]);
            entity.Vendor = row["vendor"].ToString();
            entity.PhoneNumber = row["phonenumber"].ToString();
            entity.Email = row["email"].ToString();
            entity.CreateDate = Convert.ToDateTime(row["createdate"]);
            entity.ParentUserName = row["parent_username"] == null ?  "" : row["parent_username"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(UserInfo entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("username", entity.UserName);
            table.Add("password", entity.Password);
            table.Add("userlevel", entity.UserLevel);
            table.Add("vendor", entity.Vendor);
            table.Add("phonenumber", entity.PhoneNumber);
            table.Add("email", entity.Email);
            table.Add("createdate", entity.CreateDate);
            table.Add("parent_username", entity.ParentUserName);

            return table;
        }

        /// <summary>
        /// 检查是否有重复项
        /// </summary>
        /// <param name="entity">用户对象</param>
        /// <returns></returns>
        private bool CheckDuplicate(UserInfo entity)
        {
            long count = base.Count("username", entity.UserName);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户对象</param>
        public override void Create(UserInfo entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateName);

            base.Create(entity);
        }
        #endregion //Method
    }
}
