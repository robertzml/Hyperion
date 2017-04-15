using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hyperion.WebUI.Controllers
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;
    using Hyperion.WebUI.Models;
    using Hyperion.WebUI.Services;

    /// <summary>
    /// 账户控制器
    /// </summary>
    [EnhancedAuthorize]
    public class AccountController : Controller
    {
        #region Field
        /// <summary>
        /// 认证服务
        /// </summary>
        private IFormsAuthenticationService formsService;
        #endregion //Field

        #region Function
        protected override void Initialize(RequestContext requestContext)
        {
            if (formsService == null)
            {
                formsService = new FormsAuthenticationService();
            }
            base.Initialize(requestContext);
        }
        #endregion //Function

        #region Action
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录 - POST
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                formsService.SignOut();
                HttpContext.Session.Clear();

                string pass = Hasher.MD5Encrypt(model.Password).ToUpper();
                var result = CallerFactory<IUserInfoService>.Instance.Login(model.UserName, pass);
                if (result)
                {
                    var user = CallerFactory<IUserInfoService>.Instance.FindByUserName(model.UserName);
                    HttpCookie cookie = formsService.SignIn(user.UserName, user.UserLevel.ToString(), model.RememberMe);
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误");
                }
            }

            return View(model);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            formsService.SignOut();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 管理用户列表
        /// </summary>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "0")]
        [HttpGet]
        public ActionResult List()
        {
            var data = CallerFactory<IUserInfoService>.Instance.FindAll();
            return View(data);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "0")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CallerFactory<IUserInfoService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "0")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "0")]
        [HttpPost]
        public ActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserInfo entity = new UserInfo();
                    entity.UserName = model.UserName;
                    entity.Password = Hasher.MD5Encrypt(model.Password).ToUpper();
                    entity.UserLevel = 1;
                    entity.Vendor = model.Vendor;
                    entity.PhoneNumber = model.PhoneNumber;
                    entity.Email = model.Email;
                    entity.ParentUserName = User.Identity.Name;
                    entity.CreateDate = DateTime.Now;

                    CallerFactory<IUserInfoService>.Instance.Create(entity);

                    TempData["Message"] = "添加用户成功";
                    return RedirectToAction("List");
                }
                catch (PoseidonException e)
                {
                    ModelState.AddModelError("", "添加用户失败：" + e.Message);
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "0")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = CallerFactory<IUserInfoService>.Instance.FindById(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "0")]
        [HttpPost]
        public ActionResult Edit(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CallerFactory<IUserInfoService>.Instance.Update(model);

                    TempData["Message"] = "编辑账户成功";
                    return RedirectToAction("List");
                }
                catch (PoseidonException e)
                {
                    ModelState.AddModelError("", "编辑账户失败：" + e.Message);
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}