using System.Web.Mvc;

namespace WebApplication1.Areas.Business
{
    public class BusinessAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Business";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Business",
                "Business/WebApp/Welcome",
                new { controller = "WebApp", action = "Welcome", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Business_Logout",
                "Business/WebApp/Logout",
                new { controller = "WebApp", action = "Logout" }
                 );
            context.MapRoute(
                "Business_Settings",
                "Business/WebApp/Settings",
                new { controller = "WebApp", action = "Settings" }
                 );
            context.MapRoute(
                 "Business_error",
                  "Business/{*url}",
                  new { controller = "Error", action = "PageNotFound", area = "" }
             );

        }
    }
}