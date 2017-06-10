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
    /// 厂家访问服务接口
    /// </summary>
    public interface IVendorService : IBaseService<Vendor, string>
    {
        /// <summary>
        /// 按名称查找厂商
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        Vendor FindByName(string name);
    }
}
