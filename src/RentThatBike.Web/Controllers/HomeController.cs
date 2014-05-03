using System.Linq;
using System.Web.Mvc;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.Mvc;

namespace RentThatBike.Web.Controllers
{
    public class HomeController : ServiceStackController
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