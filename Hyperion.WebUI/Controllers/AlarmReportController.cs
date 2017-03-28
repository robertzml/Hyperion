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
    /// 故障维护控制器
    /// </summary>
    [EnhancedAuthorize]
    public class AlarmReportController : Controller
    {
        #region Action
        /// <summary>
        /// 故障维护列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var data = CallerFactory<IAlarmReportService>.Instance.FindAll();
            return View(data);
        }

        /// <summary>
        /// 故障维护信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CallerFactory<IAlarmReportService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }
        #endregion //Action
    }
}