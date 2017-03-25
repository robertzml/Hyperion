using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hyperion.WebUI.Controllers
{
    using Poseidon.Base.Framework;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;

    /// <summary>
    /// 设备管理控制器
    /// </summary>
    [EnhancedAuthorize]
    public class EquipmentController : Controller
    {
        #region Action
        /// <summary>
        /// 设备列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            var data = CallerFactory<IEquipmentManagerService>.Instance.FindAll();
            return View(data);
        }

        /// <summary>
        /// 设备信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CallerFactory<IEquipmentManagerService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }
        #endregion //Action
    }
}