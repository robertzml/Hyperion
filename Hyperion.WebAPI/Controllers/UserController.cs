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
    /// 设备用户控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        #region Action
        /// <summary>
        /// 设备用户列表
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var data = CallerFactory<IAccountService>.Instance.FindAll();

            return Ok(data);
        }
        #endregion //Action       
    }
}
