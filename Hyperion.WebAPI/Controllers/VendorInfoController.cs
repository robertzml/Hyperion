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
            List<VendorInfo> data = new List<VendorInfo>();
            data.Add(new VendorInfo { Id = 1, Name = "Mulan", Description = "First" });
            data.Add(new VendorInfo { Id = 2, Name = "Aupu", Description = "Second" });

            return Ok(data);
        }
        #endregion //Action

        // GET: api/VendorInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VendorInfo
        public void Post([FromBody]string value)
        {
        }
    }
}
