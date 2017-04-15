using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hyperion.WebUI.Api
{
    using Poseidon.Base.Framework;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;

    /// <summary>
    /// 厂家控制器
    /// </summary>
    public class VendorInfoController : ApiController
    {
        #region Action
        /// <summary>
        /// 获取所有故障维护
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var data = CallerFactory<IVendorInfoService>.Instance.FindAll();
            return Ok(data);
        }

        /// <summary>
        /// 获取故障维护
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var data = CallerFactory<IVendorInfoService>.Instance.FindById(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        #endregion //Action
    }
}
