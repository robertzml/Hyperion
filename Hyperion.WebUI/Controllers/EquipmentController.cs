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

        /// <summary>
        /// 用户相关设备列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListByUser(int userId)
        {
            var user = CallerFactory<IAccountService>.Instance.FindById(userId);
            ViewBag.UserName = user.UserName;

            var data = CallerFactory<IEquipmentService>.Instance.FindByUserId(userId).OrderBy(r => r.Id);
            return View(data);
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(EquipmentManager model)
        {
            if (ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;

                var entity = CallerFactory<IEquipmentManagerService>.Instance.Create(model);
                if (entity == null)
                {
                    ModelState.AddModelError("", "添加设备失败");
                }
                else
                {
                    //return RedirectToAction("Details", new { id = entity.Id });
                    TempData["Message"] = "添加设备成功";
                    return RedirectToAction("List");
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = CallerFactory<IEquipmentManagerService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(EquipmentManager model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CallerFactory<IEquipmentManagerService>.Instance.Update(model);

                    TempData["Message"] = "编辑设备成功";
                    return RedirectToAction("List");
                }
                catch (PoseidonException e)
                {
                    ModelState.AddModelError("", "编辑设备失败：" + e.Message);
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}