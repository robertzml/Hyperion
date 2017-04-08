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
    /// 设备日志控制器
    /// </summary>
    [EnhancedAuthorize]
    public class OperateRecordController : Controller
    {
        #region Action
        public ActionResult List()
        {
            return View();
        }
        #endregion //Action

        #region Json
        /// <summary>
        /// 获取日志数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetData()
        {
            var form = Request.Form;
            int draw = Convert.ToInt32(form["draw"]);
            int start = Convert.ToInt32(form["start"]);
            int length = Convert.ToInt32(form["length"]);

            var records = CallerFactory<IOperateRecordService>.Instance.FindWithPage(start, length);
            var count = CallerFactory<IOperateRecordService>.Instance.Count();

            var data = new
            {
                recordsTotal = count,
                recordsFiltered = count,
                data = records
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //Json
    }
}