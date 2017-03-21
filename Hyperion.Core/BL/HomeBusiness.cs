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
    /// 房屋业务类
    /// </summary>
    public class HomeBusiness : AbstractBusiness<Home, int>, IBaseBL<Home, int>
    {
        #region Constructor
        /// <summary>
        /// 房屋业务类
        /// </summary>
        public HomeBusiness()
        {
            this.baseDal = RepositoryFactory<IHomeRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按用户ID、房屋ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="homeId">房屋ID</param>
        /// <returns></returns>
        public Home FindOne(int userId, int homeId)
        {
            var dal = this.baseDal as IHomeRepository;
            return dal.FindOne(userId, homeId);
        }

        /// <summary>
        /// 按用户ID查找对象
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<Home> FindByUser(int userId)
        {
            return this.baseDal.FindListByField("userid", userId);
        }
        #endregion //Method
    }
}
