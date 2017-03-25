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
    /// 厂家管理控制器
    /// </summary>
    [EnhancedAuthorize]
    public class VendorInfoController : Controller
    {
        #region Action
        /// <summary>
        /// 厂家列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            var data = CallerFactory<IVendorInfoService>.Instance.FindAll();
            return View(data);
        }

        /// <summary>
        /// 厂家信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CallerFactory<IVendorInfoService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }
        #endregion //Action
    }
}