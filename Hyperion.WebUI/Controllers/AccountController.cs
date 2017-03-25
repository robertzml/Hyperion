using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hyperion.WebUI.Controllers
{
    using Poseidon.Base.Framework;
    using Poseidon.Common;
    using Hyperion.Caller.Facade;
    using Hyperion.Core.DL;
    using Hyperion.WebUI.Models;
    using Hyperion.WebUI.Services;

    /// <summary>
    /// 账户控制器
    /// </summary>
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
        #endregion //Action
    }
}