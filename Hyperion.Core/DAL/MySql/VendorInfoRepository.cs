using System;
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
    using System.Collections;

    /// <summary>
    /// 厂家数据访问类
    /// </summary>
    internal class VendorInfoRepository : AbstractDALMySql<VendorInfo>, IVendorInfoRepository
    {
        #region Constructor
        public VendorInfoRepository() : base("vendor_info", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override VendorInfo DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override VendorInfo DataRowToEntity(DataRow row)
        {
            VendorInfo entity = new VendorInfo();
            entity.Id = Convert.ToInt32(row["id"]);
            entity.Name = row["vendor_name"].ToString();
            entity.Description = row["vendor_desc"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(VendorInfo entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("vendor_name", entity.Name);
            table.Add("vendor_desc", entity.Description);

            return table;
        }
        #endregion //Function
    }
}
