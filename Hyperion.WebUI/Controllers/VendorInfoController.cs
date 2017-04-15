using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hyperion.WebUI.Controllers
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
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

        /// <summary>
        /// 添加厂家
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加厂家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(VendorInfo model)
        {
            if (ModelState.IsValid)
            {
                var entity = CallerFactory<IVendorInfoService>.Instance.Create(model);
                if (entity == null)
                {
                    ModelState.AddModelError("", "添加厂家失败");
                }
                else
                {
                    TempData["Message"] = "添加厂家成功";
                    return RedirectToAction("List");
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑厂家
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = CallerFactory<IVendorInfoService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑厂家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(VendorInfo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CallerFactory<IVendorInfoService>.Instance.Update(model);

                    TempData["Message"] = "编辑厂家成功";
                    return RedirectToAction("List");
                }
                catch (PoseidonException e)
                {
                    ModelState.AddModelError("", "编辑厂家失败：" + e.Message);
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}