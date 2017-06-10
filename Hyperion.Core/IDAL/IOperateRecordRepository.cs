using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Hyperion.Core.DL;

    /// <summary>
    /// 操作日志数据访问接口
    /// </summary>
    internal interface IOperateRecordRepository : IBaseDAL<OperateRecord, long>
    {
        /// <summary>
        /// 分页查找
        /// </summary>
        /// <param name="startPos">起始位置</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        IEnumerable<OperateRecord> FindWithPage(int startPos, int count);
    }
}
