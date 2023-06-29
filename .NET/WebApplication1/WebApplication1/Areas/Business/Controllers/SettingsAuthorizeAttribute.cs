using System;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.Business.Controllers
{
    internal class SettingsAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string data = (string)filterContext.HttpContext.Session["roles"];
            ServiceAuthenticate service = new ServiceAuthenticate();
            
            if (data!="admin")
            {
                string redirectUrl = new UrlHelper(filterContext.RequestContext).Action("Welcome", "WebApp", new { area = "Business" });
                filterContext.Result = new RedirectResult(redirectUrl);
            }
        }
    }
}