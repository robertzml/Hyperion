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
    /// 设备用户访问服务接口
    /// </summary>
    internal class AccountService : AbstractLocalService<Account, int>, IAccountService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private AccountBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 设备用户访问服务接口
        /// </summary>
        public AccountService() : base(BusinessFactory<AccountBusiness>.Instance)
        {
            this.bl = this.baseBL as AccountBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按用户名查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public Account FindByName(string userName)
        {
            return this.bl.FindByName(userName);
        }

        /// <summary>
        /// 查找设备操控用户
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        public IEnumerable<Account> FindByEquipment(string serialNumber)
        {
            return this.bl.FindByEquipment(serialNumber);
        }
        #endregion //Method
    }
}
