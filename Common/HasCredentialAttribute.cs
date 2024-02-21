using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBookStore.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { set; get; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if (session == null)
            {

                return false;
            }
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser();
            if (privilegeLevels.Contains(this.RoleID) || session.MaNhom == CommonConstants.ADMIN_GROUP)
            {
                return true;
            } else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if (session == null)
            {

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                     (new { controller = "Account", action = "Login", area = "Admin" }));
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Areas/Admin/Views/Shared/UnAuthorized.cshtml"
                };
            }
        }

        private List<string> GetCredentialByLoggedInUser()
        {
            var credentials = (List<string>) HttpContext.Current.Session[CommonConstants.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}