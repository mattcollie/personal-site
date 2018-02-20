using System.Web.Mvc;

namespace Profile.Web.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}