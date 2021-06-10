using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace DynamicProviders.NetFrameworkApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = $"Secured page. User: {(User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(c => c.Type == "iss")}.";

            return View();
        }
    }
}