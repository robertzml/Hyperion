using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Hyperion.Core.DAL.MySQL
{
    using MySql.Data.MySqlClient;
    using Poseidon.Base.System;
    using Poseidon.Data;
    using Hyperion.Core.Abstract;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;

    /// <summary>
    /// 用户信息数据访问类
    /// </summary>
    internal class AccountInfoRepository : AbstractDALMySql<AccountInfo>, IAccountInfoRepository
    {
        #region Constructor
        public AccountInfoRepository() : base("account_info", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override AccountInfo DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override AccountInfo DataRowToEntity(DataRow row)
        {
            AccountInfo entity = new AccountInfo();
            entity.Id = Convert.ToInt32(row["id"]);
            entity.UserName = row["username"].ToString();
            entity.IDCard = row["IDCard"].ToString();
            entity.Birthday = row["birthday"].ToString();
            entity.Email = row["email"].ToString();
            entity.RealUserName = row["realusername"].ToString();

            if (row.IsNull("sex"))
                entity.Sex = null;
            else
                entity.Sex = Convert.ToInt16(row["sex"]);

            if (row.IsNull("age"))
                entity.Age = null;
            else
                entity.Age = Convert.ToInt16(row["age"]);

            entity.Horoscope = row["horoscope"].ToString();

            if (row.IsNull("height"))
                entity.Height = null;
            else
                entity.Height = Convert.ToInt16(row["height"]);

            if (row.IsNull("weight"))
                entity.Weight = null;
            else
                entity.Weight = Convert.ToInt16(row["weight"]);

            entity.FamilyAddress = row["family_address"].ToString();
            entity.Profession = row["profession"].ToString();
            entity.Company = row["company"].ToString();
            entity.ReservePhoneNo = row["reserve_phoneNO"].ToString();
            entity.ReserveEmail = row["reserve_email"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(AccountInfo entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("username", entity.UserName);
            table.Add("IDCard", entity.IDCard);
            table.Add("birthday", entity.Birthday);
            table.Add("email", entity.Email);
            table.Add("realusername", entity.RealUserName);
            table.Add("sex", entity.Sex);
            table.Add("age", entity.Age);
            table.Add("horoscope", entity.Horoscope);
            table.Add("height", entity.Height);
            table.Add("weight", entity.Weight);
            table.Add("family_address", entity.FamilyAddress);
            table.Add("profession", entity.Profession);
            table.Add("company", entity.Company);
            table.Add("reserve_phoneNO", entity.ReservePhoneNo);
            table.Add("reserve_email", entity.ReserveEmail);

            return table;
        }
        #endregion //Function
    }
}
