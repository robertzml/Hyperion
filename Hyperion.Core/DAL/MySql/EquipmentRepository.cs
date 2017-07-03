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
    /// 设备数据访问类
    /// </summary>
    internal class EquipmentRepository : AbstractDALMySql<Equipment, long>, IEquipmentRepository
    {
        #region Constructor
        public EquipmentRepository() : base("t_equipment", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Equipment DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Equipment DataRowToEntity(DataRow row)
        {
            Equipment entity = new Equipment();
            entity.Id = Convert.ToInt64(row["id"]);
            entity.SerialNumber = row["serial_number"].ToString();
            entity.Vendor = row["vendor"].ToString();
            entity.ControllerModel = row["controller_model"].ToString();
            entity.Version = row["version"].ToString();
            entity.Type = row["type"].ToString();
            entity.FunctionCode = row["function_code"].ToString();
            entity.UpgradeVersion = row["upgrade_version"].ToString();
            entity.CreateTime = Convert.ToDateTime(row["create_time"]);
            entity.UpdateTime = Convert.ToDateTime(row["update_time"]);
            entity.Online = Convert.ToInt32(row["online"]);
            entity.Status = Convert.ToInt32(row["status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Equipment entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("serial_number", entity.SerialNumber);
            table.Add("vendor", entity.Vendor);
            table.Add("controller_model", entity.ControllerModel);
            table.Add("version", entity.Version);
            table.Add("type", entity.Type);
            table.Add("function_code", entity.FunctionCode);
            table.Add("upgrade_version", entity.UpgradeVersion);
            table.Add("create_time", entity.CreateTime);
            table.Add("update_time", entity.UpdateTime);
            table.Add("online", entity.Online);
            table.Add("status", entity.Status);

            return table;
        }
        #endregion //Function

        #region Method
        //public override Equipment FindById(long id)
        //{
        //    string sql = string.Format("Select * From {0} Where ({1} = {2}{1})", this.tableName, this.primaryKey, parameterPrefix);
        //    base.mysql.AddParameter(this.primaryKey, id);

        //    var row = this.mysql.ExecuteRow(sql);
        //    if (row == null)
        //        return null;
        //    else
        //    {
        //        var entity = DataRowToEntity(row);
        //        return entity;
        //    }
        //}
        #endregion //Method
    }
}
