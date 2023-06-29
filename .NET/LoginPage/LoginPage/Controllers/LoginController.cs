using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginPage.Models;

namespace LoginPage.Controllers
{
    public class LoginController : Controller
    {
        dbClass dbop = new dbClass();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            int res = dbop.LoginCheck(username, password);
            if (res == 1)
            {
                return View("LoginSuccess");
            }
            else
            {
                ViewBag.ErrorMessage = "Please enter a valid username and password.";
                return View("Index");
            }
        }
    }
}