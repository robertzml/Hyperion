using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    /// <summary>
    /// 故障维护访问服务类
    /// </summary>
    internal class AlarmReportService : AbstractLocalService<AlarmReport, int>, IAlarmReportService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private AlarmReportBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 故障维护访问服务类
        /// </summary>
        public AlarmReportService() : base(BusinessFactory<AlarmReportBusiness>.Instance)
        {
            this.bl = this.baseBL as AlarmReportBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 分页方式获取数据
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<AlarmReport> FindWithPage(int startPos, int count)
        {
            return this.bl.FindWithPage(startPos, count);
        }

        /// <summary>
        /// 按用户查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<AlarmReport> FindByUser(int userId)
        {
            return this.bl.FindByUser(userId);
        }
        #endregion //Method
    }
}
