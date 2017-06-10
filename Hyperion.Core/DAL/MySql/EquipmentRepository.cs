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
    internal class EquipmentRepository : AbstractDALMySql<Equipment, string>, IEquipmentRepository
    {
        #region Constructor
        public EquipmentRepository() : base("equipment", "id")
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
            entity.Id = row["id"].ToString();
            entity.SerialNumber = row["serial_number"].ToString();
            entity.ControllerModel = row["controller_model"].ToString();
            entity.Version = row["version"].ToString();
            entity.EquipmentModel = row["equipment_model"].ToString();
            entity.Vendor = row["vendor"].ToString();
            entity.CreateTime = Convert.ToDateTime(row["create_time"]);
            entity.Remark = row["remark"].ToString();
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
            table.Add("controller_model", entity.ControllerModel);
            table.Add("version", entity.Version);
            table.Add("equipment_model", entity.EquipmentModel);
            table.Add("vendor", entity.Vendor);
            table.Add("create_time", entity.CreateTime);
            table.Add("remark", entity.Remark);
            table.Add("status", entity.Status);

            return table;
        }
        #endregion //Function

        #region Method

        #endregion //Method
    }
}
