using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    /// <summary>
    /// 用户数据访问类
    /// </summary>
    internal class UserRepository : AbstractDALMySql<User, long>, IUserRepository
    {
        #region Constructor
        /// <summary>
        /// 用户数据访问类
        /// </summary>
        public UserRepository() : base("t_user", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override User DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override User DataRowToEntity(DataRow row)
        {
            User entity = new User();
            entity.Id = Convert.ToInt64(row["id"]);
            entity.UserId = Convert.ToInt32(row["user_id"]);
            entity.UserName = row["user_name"].ToString();
            entity.UserType = Convert.ToInt16(row["user_type"]);
            entity.IMEI = row["imei"].ToString();
            entity.LoginState = Convert.ToInt16(row["login_state"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(User entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("user_id", entity.UserId);
            table.Add("user_name", entity.UserName);
            table.Add("user_type", entity.UserType);
            table.Add("imei", entity.IMEI);
            table.Add("login_state", entity.LoginState);

            return table;
        }
        #endregion //Function
    }
}
