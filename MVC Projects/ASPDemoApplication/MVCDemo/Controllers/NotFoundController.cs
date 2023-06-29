using System;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class NotFoundController : Controller
    {
        // GET: NotFound
        public ActionResult NotFound()
        {
            return View();
        }
    }
}