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
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    /// <summary>
    /// 设备报警控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquipmentAlarmController : ApiController
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private EquipmentAlarmBusiness bl = null;
        #endregion //Field

        #region Constructor
        public EquipmentAlarmController()
        {
            this.bl = BusinessFactory<EquipmentAlarmBusiness>.Instance;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取设备报警列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = this.bl.FindAll();

            return Ok(data);
        }

        /// <summary>
        /// 获取设备报警信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var data = this.bl.FindById(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// 获取设备状态信息
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetBySerialNumber(string serialNumber)
        {
            var data = this.bl.FindBySerialNumber(serialNumber);

            return Ok(data);
        }
        #endregion //Action
    }
}
