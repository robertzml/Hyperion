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
    /// 用户设备数据访问类
    /// </summary>
    internal class UserEquipmentRepository : AbstractDALMySql<UserEquipment, long>, IUserEquipmentRepository
    {
        #region Constructor
        /// <summary>
        /// 用户设备数据访问类
        /// </summary>
        public UserEquipmentRepository() : base("t_user_equipment", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override UserEquipment DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override UserEquipment DataRowToEntity(DataRow row)
        {
            UserEquipment entity = new UserEquipment();
            entity.Id = Convert.ToInt64(row["id"]);
            entity.UserId = Convert.ToInt32(row["user_id"]);
            entity.HomeId = Convert.ToInt32(row["home_id"]);
            entity.RoomId = Convert.ToInt32(row["room_id"]);
            entity.SerialNumber = row["serial_number"].ToString();
            entity.DeviceName = row["device_name"].ToString();
            entity.CreateDate = Convert.ToDateTime(row["create_date"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(UserEquipment entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("user_id", entity.UserId);
            table.Add("home_id", entity.HomeId);
            table.Add("room_id", entity.RoomId);
            table.Add("serial_number", entity.SerialNumber);
            table.Add("device_name", entity.DeviceName);
            table.Add("create_date", entity.CreateDate);

            return table;
        }
        #endregion //Function
    }
}
