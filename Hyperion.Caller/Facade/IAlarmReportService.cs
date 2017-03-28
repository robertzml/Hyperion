using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 故障维护访问服务接口
    /// </summary>
    public interface IAlarmReportService : IBaseService<AlarmReport, int>
    {
        /// <summary>
        /// 分页方式获取数据
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<AlarmReport> FindWithPage(int startPos, int count);

        /// <summary>
        /// 按用户查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        IEnumerable<AlarmReport> FindByUser(int userId);
    }
}
