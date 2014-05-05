using System.Linq;
using System.Web.Mvc;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.CacheAccess;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace RentThatBike.Web.Controllers
{
    [Authenticate]
    public class HomeController : ServiceStackController<AuthUserSession>
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.AuthUserSession = UserSession;
            return View();
        }
	}
}