using System.Web.Mvc;
using RentThatBike.Web.Models;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.Text;

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

            ViewBag.ServerSideDataAsJson = new ServerSideData
            {
                UserDisplayName = UserSession.DisplayName,
                UserEmail = UserSession.Email
            }.ToJson(); 

            return View();
        }
	}
}