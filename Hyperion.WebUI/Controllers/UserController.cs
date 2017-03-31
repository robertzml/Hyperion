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
    /// 设备用户控制器
    /// </summary>
    public class UserController : Controller
    {
        #region Action
        /// <summary>
        /// 设备用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            var data = CallerFactory<IAccountService>.Instance.FindAll();
            return View(data);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CallerFactory<IAccountService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();
            return View(data);
        }

        /// <summary>
        /// 设备用户信息
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListByEquipment(string serialNumber)
        {
            var data = CallerFactory<IAccountService>.Instance.FindByEquipment(serialNumber);
            ViewBag.SerialNumber = serialNumber;
            return View(data);
        }
        #endregion //Action
    }
}