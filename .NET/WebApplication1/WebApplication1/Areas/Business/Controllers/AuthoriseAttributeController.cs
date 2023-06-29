using System;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Areas.Business.Controllers
{
    internal class AuthoriseAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            UserData data = (UserData)filterContext.HttpContext.Session["user"];
            ServiceAuthenticate service = new ServiceAuthenticate();
            bool flag = service.Authenticate(data);
            if (!flag)
            {
                string redirectUrl = new UrlHelper(filterContext.RequestContext).Action("Index", "Home", new { area = "" });
                filterContext.Result = new RedirectResult(redirectUrl);
            }
        }

    }
}
