using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hyperion.WebAPI.Controllers
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;

    /// <summary>
    /// 厂家管理控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendorInfoController : ApiController
    {
        #region Action
        /// <summary>
        /// 厂家列表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var data = CallerFactory<IVendorService>.Instance.FindAll();

            return Ok(data);
        }

        /// <summary>
        /// 厂家信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public IHttpActionResult Get(string id)
        {
            var data = CallerFactory<IVendorService>.Instance.FindById(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        #endregion //Action
    }
}
