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
    internal class OperateRecordRepository : AbstractDALMySql<OperateRecord>, IOperateRecordRepository
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
            entity.Id = Convert.ToInt32(row["id"]);
            entity.LogType = Convert.ToInt16(row["logtype"]);
            entity.LogTime = Convert.ToDateTime(row["logtime"]);
            entity.OpType = Convert.ToInt16(row["optype"]);
            entity.UserName = row["username"].ToString();
            entity.IMSI = row["imsi"].ToString();
            entity.IMEI = row["imei"].ToString();
            entity.MSISDN = row["msisdn"].ToString();

            if (row.IsNull("ostype"))
                entity.OSType = null;
            else
                entity.OSType = Convert.ToInt16(row["ostype"]);

            entity.SerialNumber = row["serialnumber"].ToString();
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
            table.Add("username", entity.UserName);
            table.Add("imsi", entity.IMSI);
            table.Add("imei", entity.IMEI);
            table.Add("msisdn", entity.MSISDN);
            table.Add("ostype", entity.OSType);
            table.Add("serialnumber", entity.SerialNumber);
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

            return base.FindWithPage(condition, paras, startPos, count);
        }
        #endregion //Method
    }
}
