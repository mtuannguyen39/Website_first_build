using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website_first_build.Filter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["RoleUser"] == null)
            {
                return false;
            }
            var role = httpContext.Session["RoleUser"].ToString();
            // Kiểm tra quyền truy cập dựa trên vai trò
            if(role == "Admin" || role == "DangTin" || role == "QuanLy")
            {
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Admins/Index");
        }
    }
}