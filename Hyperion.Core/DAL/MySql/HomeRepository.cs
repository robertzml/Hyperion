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
    /// 房屋数据访问类
    /// </summary>
    internal class HomeRepository : AbstractDALMySql<Home>, IHomeRepository
    {
        #region Constructor
        public HomeRepository() : base("home", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Home DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Home DataRowToEntity(DataRow row)
        {
            Home entity = new Home();
            entity.UserId = Convert.ToInt32(row["userid"]);
            entity.HomeId = Convert.ToInt32(row["homeid"]);
            entity.Name = row["name"].ToString();
            entity.Info = row["info"].ToString();
            entity.Position = row["position"].ToString();
            entity.Latitude = row["latitude"].ToString();
            entity.Longitude = row["longitude"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Home entity)
        {
            Hashtable table = new Hashtable();
            table.Add("userid", entity.UserId);
            table.Add("homeid", entity.HomeId);
            table.Add("name", entity.Name);
            table.Add("info", entity.Info);
            table.Add("position", entity.Position);
            table.Add("latitude", entity.Latitude);
            table.Add("longitude", entity.Longitude);

            return table;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 禁用按ID查找对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Home FindById(int id)
        {
            throw new PoseidonException(ErrorCode.NotImplement);
        }

        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <returns></returns>
        public Home FindOne(int userId, int homeId)
        {
            string sql = string.Format("userid = {0}userid AND homeid = {0}homeid", this.parameterPrefix);

            List<MySqlParameter> paras = new List<MySqlParameter>();
            paras.Add(new MySqlParameter("userid", userId));
            paras.Add(new MySqlParameter("homeid", homeId));

            var entity = base.FindOne(sql, paras);
            return entity;
        }
        #endregion //Method
    }
}
