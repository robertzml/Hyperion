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
    /// 操作日志数据访问类
    /// </summary>
    internal class OperateRecordRepository : AbstractDALMySql<OperateRecord, long>, IOperateRecordRepository
    {
        #region Constructor
        public OperateRecordRepository() : base("operate_record", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override OperateRecord DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override OperateRecord DataRowToEntity(DataRow row)
        {
            OperateRecord entity = new OperateRecord();
            entity.Id = Convert.ToInt64(row["id"]);
            entity.LogType = Convert.ToInt32(row["log_type"]);
            entity.LogTime = Convert.ToDateTime(row["log_time"]);
            entity.OpType = Convert.ToInt32(row["op_type"]);
            entity.SerialNumber = row["serialnumber"].ToString();
            entity.OpSource = Convert.ToInt32(row["op_source"]);
            entity.OpUser = row["op_user"].ToString();
            entity.OpIdentity = row["op_identity"].ToString();
            entity.RequestBody = row["requestbodyofaction"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(OperateRecord entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("logtype", entity.LogType);
            table.Add("logtime", entity.LogTime);
            table.Add("optype", entity.OpType);
            table.Add("serialnumber", entity.SerialNumber);
            table.Add("op_source", entity.OpSource);
            table.Add("op_user", entity.OpUser);
            table.Add("op_identity", entity.OpIdentity);
            table.Add("requestbodyofaction", entity.RequestBody);

            return table;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 分页查找
        /// </summary>
        /// <param name="startPos">起始位置</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public IEnumerable<OperateRecord> FindWithPage(int startPos, int count)
        {
            string condition = "1 = 1";
            List<MySqlParameter> paras = new List<MySqlParameter>();

            return base.FindWithPage(condition, paras, "id", "DESC", startPos, count);
        }
        #endregion //Method
    }
}
