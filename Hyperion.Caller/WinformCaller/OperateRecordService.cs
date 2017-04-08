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
    /// 操作记录访问服务类
    /// </summary>
    internal class OperateRecordService : AbstractLocalService<OperateRecord, int>, IOperateRecordService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private OperateRecordBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 操作记录访问服务类
        /// </summary>
        public OperateRecordService() : base(BusinessFactory<OperateRecordBusiness>.Instance)
        {
            this.bl = this.baseBL as OperateRecordBusiness;
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
            return this.bl.FindWithPage(startPos, count);
        }
        #endregion //Method
    }
}
