using System.Web.Mvc;

namespace Hello
{
    public class WebController : Controller
    {
        // GET: Web
        public ActionResult Index()
        {
            return View();
        }
    }
}