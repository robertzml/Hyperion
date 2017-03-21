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
    /// 房间数据访问类
    /// </summary>
    internal class RoomRepository : AbstractDALMySql<Room>, IRoomRepository
    {
        #region Constructor
        public RoomRepository() : base("room", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Room DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Room DataRowToEntity(DataRow row)
        {
            Room entity = new Room();
            entity.UserId = Convert.ToInt32(row["userid"]);
            entity.HomeId = Convert.ToInt32(row["homeid"]);
            entity.RoomId = Convert.ToInt32(row["roomid"]);
            entity.Name = row["name"].ToString();
            entity.RoomType = Convert.ToInt16(row["roomtype"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Room entity)
        {
            Hashtable table = new Hashtable();
            table.Add("userid", entity.UserId);
            table.Add("homeid", entity.HomeId);
            table.Add("roomid", entity.RoomId);
            table.Add("name", entity.Name);
            table.Add("roomtype", entity.RoomType);

            return table;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 禁用按ID查找对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Room FindById(int id)
        {
            throw new PoseidonException(ErrorCode.NotImplement);
        }

        /// <summary>
        /// 按用户ID、房屋ID，房间ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public Room FindOne(int userId, int homeId, int roomId)
        {
            string sql = string.Format("userid = {0}userid AND homeid = {0}homeid AND roomid = {0}roomid", this.parameterPrefix);

            List<MySqlParameter> paras = new List<MySqlParameter>();
            paras.Add(new MySqlParameter("userid", userId));
            paras.Add(new MySqlParameter("homeid", homeId));
            paras.Add(new MySqlParameter("roomid", roomId));

            var entity = base.FindOne(sql, paras);
            return entity;
        }

        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <returns></returns>
        public IEnumerable<Room> FindInHome(int userId, int homeId)
        {
            string sql = string.Format("userid = {0}userid AND homeid = {0}homeid", this.parameterPrefix);

            List<MySqlParameter> paras = new List<MySqlParameter>();
            paras.Add(new MySqlParameter("userid", userId));
            paras.Add(new MySqlParameter("homeid", homeId));

            return base.FindList(sql, paras);
        }
        #endregion //Method
    }
}
