using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Areas.Business.Controllers
{
    [AuthoriseAttribute]
    public class WebAppController : Controller
    {
        // GET: Business/WebApp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Private()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
            //return View("Index");
        }
        [SettingsAuthorize]
        public ActionResult Settings()
        {

            return View("Settings");

        }


    }
}