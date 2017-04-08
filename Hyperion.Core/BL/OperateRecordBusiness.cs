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
    /// 操作日志业务类
    /// </summary>
    public class OperateRecordBusiness : AbstractBusiness<OperateRecord, int>, IBaseBL<OperateRecord, int>
    {
        #region Constructor
        /// <summary>
        /// 操作日志业务类
        /// </summary>
        public OperateRecordBusiness()
        {
            this.baseDal = RepositoryFactory<IOperateRecordRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 分页查找
        /// </summary>
        /// <param name="startPos">起始位置</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public IEnumerable<OperateRecord> FindWithPage(int startPos, int count)
        {
            var dal = this.baseDal as IOperateRecordRepository;
            return dal.FindWithPage(startPos, count);
        }
        #endregion //Method
    }
}
