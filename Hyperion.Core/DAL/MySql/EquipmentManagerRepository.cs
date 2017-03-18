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
    /// 设备管理数据访问类
    /// </summary>
    internal class EquipmentManagerRepository : AbstractDALMySql<EquipmentManager, int>, IEquipmentManagerRepository
    {
        #region Constructor
        public EquipmentManagerRepository() : base("equipment_manager", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override EquipmentManager DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override EquipmentManager DataRowToEntity(DataRow row)
        {
            EquipmentManager entity = new EquipmentManager();
            entity.Id = Convert.ToInt32(row["id"]);
            entity.SerialNumber = row["serialnumber"].ToString();
            entity.Vendor = row["vendor"].ToString();
            entity.Type = row["type"].ToString();
            entity.Version = row["version"].ToString();
            entity.UpgradeVersion = row["upgrade_version"].ToString();
            entity.Owner = row["owner"].ToString();
            entity.PhoneNo = row["phoneNO"].ToString();

            if (row.IsNull("state"))
                entity.State = null;
            else
                entity.State = Convert.ToInt16(row["state"]);

            if (row.IsNull("createdate"))
                entity.CreateDate = null;
            else
                entity.CreateDate = Convert.ToDateTime(row["createdate"]);

            if (row.IsNull("updatedate"))
                entity.UpdateDate = null;
            else
                entity.UpdateDate = Convert.ToDateTime(row["updatedate"]);

            entity.UserName = row["username"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(EquipmentManager entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("serialnumber", entity.SerialNumber);
            table.Add("vendor", entity.Vendor);
            table.Add("type", entity.Type);
            table.Add("version", entity.Version);
            table.Add("upgrade_version", entity.UpgradeVersion);
            table.Add("owner", entity.Owner);
            table.Add("phoneNO", entity.PhoneNo);
            table.Add("state", entity.State);
            table.Add("createdate", entity.CreateDate);
            table.Add("updatedate", entity.UpdateDate);
            table.Add("username", entity.UserName);

            return table;
        }
        #endregion //Function
    }
}
