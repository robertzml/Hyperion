using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;

namespace Hyperion.WebAPI
{
    using Poseidon.Common;
    using Hyperion.WebAPI.Utility;

    /// <summary>
    /// 访问认证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AccessFilterAttribute : ActionFilterAttribute
    {
        #region Method
        /// <summary>
        /// Action执行前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Headers.Contains("auth"))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, HttpErrorMessage.BadRequest.DisplayName());
            }
            else
            {
                if (!actionContext.ActionArguments.ContainsKey("accessId"))
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, HttpErrorMessage.AuthFailed.DisplayName());
                }
                else
                {
                    var auth = actionContext.Request.Headers.GetValues("auth").First();
                    string accessId = actionContext.ActionArguments["accessId"].ToString();

                    if (auth != Hasher.SHA1Encrypt(accessId + HyperionConstant.Salt))
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, HttpErrorMessage.AuthFailed.DisplayName());
                }
            }

            base.OnActionExecuting(actionContext);
        }
        #endregion //Method
    }
}