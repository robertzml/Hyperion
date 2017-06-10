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
    /// 厂家业务类
    /// </summary>
    public class VendorBusiness : AbstractBusiness<Vendor, string>, IBaseBL<Vendor, string>
    {
        #region Constructor
        /// <summary>
        /// 厂家业务类
        /// </summary>
        public VendorBusiness()
        {
            this.baseDal = RepositoryFactory<IVendorRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加厂家，采用自定义主键
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Vendor Create(Vendor entity)
        {
            return base.Create(entity, false);
        }

        /// <summary>
        /// 按名称查找厂家
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public Vendor FindByName(string name)
        {
            return this.baseDal.FindOneByField("name", name);
        }

        /// <summary>
        /// 按代码查找厂家
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public Vendor FindByCode(string code)
        {
            return this.baseDal.FindOneByField("code", code);
        }
        #endregion //Method
    }
}
