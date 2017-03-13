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
            base.Init("user_info", ConnectionSource.Code, "");
        }
        #endregion //Constructor

        #region Function
        protected override UserInfo DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        protected override UserInfo DataRowToEntity(DataRow row)
        {
            throw new NotImplementedException();
        }

        protected override Hashtable EntityToHash(UserInfo entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Function
    }
}
