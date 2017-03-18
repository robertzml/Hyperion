using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.BL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;
    using Hyperion.Core.IDAL;

    /// <summary>
    /// 故障业务类
    /// </summary>
    public class AlarmReportBusiness : AbstractBusiness<AlarmReport, int>, IBaseBL<AlarmReport, int>
    {
        #region Constructor
        /// <summary>
        /// 故障业务类
        /// </summary>
        public AlarmReportBusiness()
        {
            this.baseDal = RepositoryFactory<IAlarmReportRepository>.Instance;
        }
        #endregion //Constructor
    }
}
