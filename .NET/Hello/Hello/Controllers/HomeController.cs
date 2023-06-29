using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hello.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index(string id)
        {
            return "hello "+id+Request.QueryString["name";
        }
        public ActionResult List()
        {
            return new List<string>()
            {
                "Kiki",
                "Raji",
                "Lohi"
            };
        }
       
    }
}