using System.Web.Mvc;
using Onion.Web.UOW;

namespace Onion.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FooterSlider()
        {
            return PartialView("_FooterSlider", unitOfWork.SongService.GetSongsOrderedByVisit());
        }

        public ActionResult Favorites()
        {
            return PartialView(unitOfWork.SongService.GetFavoritesSongs());
        }

        public ActionResult LatestSongsHeader()
        {
            return PartialView(unitOfWork.SongService.GetLatestSongsForHeader());
        }

        public ActionResult SiteSliders()
        {
            return PartialView(unitOfWork.SliderService.GetActivatedSliders());
        }
    }
}