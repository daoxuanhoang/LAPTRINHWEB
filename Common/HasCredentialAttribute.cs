using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Common
{
    public class HasCredentialAttribute: AuthorizeAttribute
    {
        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[OnlineShop.Common.CommonContants.USER_SESSION];
            if(session == null)
            {
                return false;
            }
            List<string> privilegeLevels = this.GetCredentialByLgoggedInUser(session.UserName);
            if(privilegeLevels.Contains(this.RoleID) || session.GroupID == OnlineShop.Common.CommonConstants2.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }
        private List<string> GetCredentialByLgoggedInUser(string userName )
        {
            var credentials = (List<string>)HttpContext.Current.Session[OnlineShop.Common.CommonContants.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}