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
    /// 故障数据访问类
    /// </summary>
    internal class EquipmentAlarmRepository : AbstractDALMySql<EquipmentAlarm, long>, IEquipmentAlarmRepository
    {
        #region Constructor
        public EquipmentAlarmRepository() : base("t_equipment_alarm", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override EquipmentAlarm DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override EquipmentAlarm DataRowToEntity(DataRow row)
        {
            EquipmentAlarm entity = new EquipmentAlarm();
            entity.Id = Convert.ToInt64(row["id"]);
            entity.SerialNumber = row["serial_number"].ToString();
            entity.AlarmCode = row["alarm_code"].ToString();
            entity.AlarmTime = Convert.ToDateTime(row["alarm_time"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(EquipmentAlarm entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("serial_number", entity.SerialNumber);
            table.Add("alarm_code", entity.AlarmCode);
            table.Add("alarm_time", entity.AlarmTime);

            return table;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 分页方式查找对象
        /// </summary>
        /// <param name="startPos">起始位置</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public IEnumerable<EquipmentAlarm> FindWithPage(int startPos, int count)
        {
            string condition = "1 = 1";
            List<MySqlParameter> paras = new List<MySqlParameter>();

            return base.FindWithPage(condition, paras, startPos, count);
        }
        #endregion //Method
    }
}
