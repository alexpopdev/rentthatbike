using System.Linq;
using System.Web.Mvc;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.CacheAccess;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;

namespace RentThatBike.Web.Controllers
{
    public class HomeController : Controller
    {
        public BicyleRepository BicyleRepository { get; set; }
        
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.BicyclesCount = BicyleRepository.GetAll().Count();
            return View();
        }
	}
}