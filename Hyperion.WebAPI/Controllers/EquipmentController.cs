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
    /// 设备控制器
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EquipmentController : ApiController
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private EquipmentBusiness bl = null;
        #endregion //Field

        #region Constructor
        public EquipmentController()
        {
            this.bl = BusinessFactory<EquipmentBusiness>.Instance;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = this.bl.FindAll();

            return Ok(data);
        }

        /// <summary>
        /// 获取设备信息
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

        public IHttpActionResult GetByFake(long fake)
        {
            Equipment entity = new Equipment();
            entity.Id = fake;

            return Ok(entity);
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [Route("api/equipment/serialNumber/{serialNumber}")]
        [HttpGet]
        public IHttpActionResult Get(string serialNumber)
        {
            var data = this.bl.FindBySerialNumber(serialNumber);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetBySerialNumber(string serialNumber)
        {
            var data = this.bl.FindBySerialNumber(serialNumber);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="vendor">厂商</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetByVendor(string vendor)
        {
            var data = this.bl.FindByVendor(vendor);
            return Ok(data);
        }
        #endregion //Action
    }
}
