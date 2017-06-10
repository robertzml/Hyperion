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
    /// 厂家数据访问类
    /// </summary>
    internal class VendorRepository : AbstractDALMySql<Vendor, string>, IVendorRepository
    {
        #region Constructor
        public VendorRepository() : base("vendor", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Vendor DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Vendor DataRowToEntity(DataRow row)
        {
            Vendor entity = new Vendor();
            entity.Id = row["id"].ToString();
            entity.Name = row["name"].ToString();
            entity.Code = row["code"].ToString();
            entity.Remark = row["remark"].ToString();
            entity.Status = Convert.ToInt32(row["status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Vendor entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("name", entity.Name);
            table.Add("code", entity.Code);
            table.Add("remark", entity.Remark);
            table.Add("status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
