using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hyperion.WebUI.Controllers
{
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

                //ErrorCode result = this.userBusiness.Login(model.UserName, model.Password);
                //if (result == ErrorCode.Success)
                //{
                //    User user = this.userBusiness.Get(model.UserName);
                //    HttpCookie cookie = formsService.SignIn(user.UserName, user.UserTypeName(), model.RememberMe);
                //    Response.Cookies.Add(cookie);

                //    return RedirectToLocal(returnUrl);
                //}
                //else
                //{
                //    ModelState.AddModelError("", result.DisplayName());
                //}
                ModelState.AddModelError("", "密码错误");
            }

            return View(model);
        }
        #endregion //Action
    }
}