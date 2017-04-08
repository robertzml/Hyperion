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
    internal class EquipmentRepository : AbstractDALMySql<Equipment>, IEquipmentRepository
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
            entity.UserId = Convert.ToInt32(row["userid"]);
            entity.HomeId = Convert.ToInt32(row["homeid"]);
            entity.RoomId = Convert.ToInt32(row["roomid"]);
            entity.Id = Convert.ToInt32(row["id"]);
            entity.SerialNumber = row["serialnumber"].ToString();
            entity.Name = row["name"].ToString();

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
            table.Add("userid", entity.UserId);
            table.Add("homeid", entity.HomeId);
            table.Add("roomid", entity.RoomId);
            table.Add("id", entity.Id);
            table.Add("serialnumber", entity.SerialNumber);
            table.Add("name", entity.Name);

            return table;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 禁用按ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public override Equipment FindById(int id)
        {
            throw new PoseidonException(ErrorCode.NotImplement);
        }

        /// <summary>
        /// 根据用户ID和序列号查找设备
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public Equipment FindOne(int userId, string serialNumber)
        {
            string sql = string.Format("userid = {0}userid AND serialNumber = {0}serialNumber", this.parameterPrefix);

            List<MySqlParameter> paras = new List<MySqlParameter>();
            paras.Add(new MySqlParameter("userid", userId));
            paras.Add(new MySqlParameter("serialNumber", serialNumber));

            var entity = base.FindOne(sql, paras);
            return entity;
        }
        #endregion //Method
    }
}
