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
    /// 版本升级数据访问类
    /// </summary>
    internal class UpgradeVersionRepository : AbstractDALMySql<UpgradeVersion>, IUpgradeVersionRepository
    {
        #region Constructor
        public UpgradeVersionRepository() : base("upgrade_version", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override UpgradeVersion DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override UpgradeVersion DataRowToEntity(DataRow row)
        {
            UpgradeVersion entity = new UpgradeVersion();
            entity.File = row["file"].ToString();
            entity.Version = Convert.ToInt16(row["version"]);
            entity.UpgradeTime = Convert.ToDateTime(row["upgrade_time"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(UpgradeVersion entity)
        {
            Hashtable table = new Hashtable();
            table.Add("file", entity.Id);
            table.Add("version", entity.Version);
            table.Add("upgrade_time", entity.UpgradeTime);

            return table;
        }
        #endregion //Function
    }
}
