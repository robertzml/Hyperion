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
    internal class AlarmReportRepository : AbstractDALMySql<AlarmReport>, IAlarmReportRepository
    {
        #region Constructor
        public AlarmReportRepository() : base("alarm_report", "id")
        {
            base.Init(ConnectionSource.Cache, Utility.HyperionConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override AlarmReport DataReaderToEntity(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override AlarmReport DataRowToEntity(DataRow row)
        {
            AlarmReport entity = new AlarmReport();
            entity.Id = Convert.ToInt32(row["id"]);

            if (row.IsNull("userid"))
                entity.UserId = null;
            else
                entity.UserId = Convert.ToInt32(row["userid"]);

            entity.UserName = row["username"].ToString();
            entity.SerialNumber = row["serialnumber"].ToString();
            entity.AlarmCode = row["alarm_code"].ToString();
            entity.AlarmDescription = row["alarm_addtion_desp"].ToString();
            entity.MSISDN = row["msisdn"].ToString();

            if (row.IsNull("dealstatus"))
                entity.DealStatus = null;
            else
                entity.DealStatus = Convert.ToInt32(row["dealstatus"]);

            if (row.IsNull("createdate"))
                entity.CreateDate = null;
            else
                entity.CreateDate = Convert.ToDateTime(row["createdate"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(AlarmReport entity)
        {
            Hashtable table = new Hashtable();
            table.Add("id", entity.Id);
            table.Add("userid", entity.UserId);
            table.Add("username", entity.UserName);
            table.Add("serialnumber", entity.SerialNumber);
            table.Add("alarm_code", entity.AlarmCode);
            table.Add("alarm_addtion_desp", entity.AlarmDescription);
            table.Add("msisdn", entity.MSISDN);
            table.Add("dealstatus", entity.DealStatus);
            table.Add("createdate", entity.CreateDate);

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
        public IEnumerable<AlarmReport> FindWithPage(int startPos, int count)
        {
            string condition = "1 = 1";
            List<MySqlParameter> paras = new List<MySqlParameter>();

            return base.FindWithPage(condition, paras, startPos, count);
        }
        #endregion //Method
    }
}
