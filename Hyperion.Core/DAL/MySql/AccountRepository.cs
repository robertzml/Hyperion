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
    internal class AccountRepository : AbstractDALMySql<Account>, IAccountRepository
    {
        #region Constructor
        public AccountRepository() : base("account", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Account DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Account DataRowToEntity(DataRow row)
        {
            Account entity = new Account();
            entity.Id = Convert.ToInt32(row["id"]);
            entity.UserName = row["username"].ToString();
            entity.Password = row["password"].ToString();
            entity.LoginState = Convert.ToInt16(row["login_state"]);
            entity.IMSI = row["imsi"].ToString();
            entity.IMEI = row["imei"].ToString();
            entity.MSISDN = row["msisdn"].ToString();
            if (row.IsNull("ostype"))
                entity.OSType = null;
            else
                entity.OSType = Convert.ToInt16(row["ostype"]);

            if (row.IsNull("updatedate"))
                entity.UpdateDate = null;
            else
                entity.UpdateDate = Convert.ToDateTime(row["updatedate"]);

            entity.CreateDate = Convert.ToDateTime(row["createdate"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Account entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("username", entity.UserName);
            table.Add("password", entity.Password);
            table.Add("login_state", entity.LoginState);
            table.Add("imsi", entity.IMSI);
            table.Add("imei", entity.IMEI);
            table.Add("msisdn", entity.MSISDN);
            table.Add("ostype", entity.OSType);
            table.Add("updatedate", entity.UpdateDate);
            table.Add("createdate", entity.CreateDate);

            return table;
        }
        #endregion //Function
    }
}
