using System;
using System.Web;
using System.Web.Mvc;

public class CheckSessionExpirationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var expirationTime = HttpContext.Current.Session["TokenExpirationTime"] as DateTime?;
        if (expirationTime != null && expirationTime.Value < DateTime.UtcNow)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new { expired = true },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                var controller = filterContext.Controller as Controller;
                var result = new ViewResult
                {
                    ViewName = "Expired",
                    ViewData = controller.ViewData,
                    TempData = controller.TempData
                };
                filterContext.Result = result;
            }
        }
    }
}
