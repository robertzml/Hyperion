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
    using System.Collections;
    using System.Data;

    /// <summary>
    /// 设备状态数据访问类
    /// </summary>
    internal class EquipmentStateRepository : AbstractDALMySql<EquipmentState, long>, IEquipmentStateRepository
    {
        #region Constructor
        public EquipmentStateRepository() : base("t_equipment_state", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override EquipmentState DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override EquipmentState DataRowToEntity(DataRow row)
        {
            EquipmentState entity = new EquipmentState();
            entity.Id = Convert.ToInt64(row["id"]);
            entity.SerialNumber = row["serial_number"].ToString();
            entity.LogTime = Convert.ToDateTime(row["log_time"]);
            entity.CummlativeHeatingTime = row["cummlative_heat_time"].ToString();
            entity.CummlativeHeatWater = row["cummlative_heat_water"].ToString();
            entity.CummlativeDurationMachine = row["cummlative_duration_machine"].ToString();
            entity.CummlativeUseElectricity = row["cummlative_use_electricity"].ToString();
            entity.CummlativeElectricitySaving = row["cummlative_electricity_saving"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(EquipmentState entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("serial_number", entity.SerialNumber);
            table.Add("log_time", entity.LogTime);
            table.Add("cummlative_heat_time", entity.CummlativeHeatingTime);
            table.Add("cummlative_heat_water", entity.CummlativeHeatWater);
            table.Add("cummlative_duration_machine", entity.CummlativeDurationMachine);
            table.Add("cummlative_use_electricity", entity.CummlativeUseElectricity);
            table.Add("cummlative_electricity_saving", entity.CummlativeElectricitySaving);

            return table;
        }
        #endregion //Function
    }
}
