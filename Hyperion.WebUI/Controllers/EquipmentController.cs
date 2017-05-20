using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hyperion.WebUI.Controllers
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;
    using Hyperion.ControlClient.Communication;
    using Hyperion.ControlClient.Protocol;

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
        /// 设备控制
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Control(int id)
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

        /// <summary>
        /// 停用设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public string Disable(int id)
        {
            Request request = new Request();
            string result = "";

            var equipment = CallerFactory<IEquipmentManagerService>.Instance.FindById(id);
            string userId = Hasher.MD5Encrypt(User.Identity.Name);
           
            WebControlMessage controlMessage = new WebControlMessage(userId, equipment.SerialNumber);

            //message.SetAction(new TLV(0x01, "0"));

            var msg1 = controlMessage.GetMessage();

            var task1 = Task.Run(() =>
            {
                var data = request.Post(msg1);
                return data;
            });

            var result1 = task1.Result;
            var content1 = result1.Content.ReadAsStringAsync().Result;
            
            WebControlAckMessage ackMessage = new WebControlAckMessage();
            ackMessage.ParseAck(content1);
            result += $"控制ACK:　{ackMessage.ServerResult.Value} \r\n";


            QueryMessage query = new QueryMessage(userId, 1);
            var msg2 = query.GetMessage();           

            var task2 = Task.Run(() =>
            {
                var data = request.Post(msg2);
                return data;
            });

            var result2 = task2.Result;
            var content2 = result2.Content.ReadAsStringAsync().Result;

            result += $"查询结果: {content2}";

            return result;
        }
        #endregion //Action
    }
}