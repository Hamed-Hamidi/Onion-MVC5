using System.Web;
using System.Web.Mvc;
using Onion.Data.Site;
using Onion.Web.UOW;
using Onion.Web.Utilities.ImageTools;

namespace Onion.Web.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        private IUnitOfWork unitOfWork;

        public SliderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            return View(unitOfWork.SliderService.GetAllSliders());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider, HttpPostedFileBase sliderImage)
        {

            if (ModelState.IsValid)
            {
                if (sliderImage != null)
                {
                    sliderImage.AddImageToServer(sliderImage.FileName, ImagePath.SliderOriginalServerPath, 150, 150, ImagePath.SliderThumbServerPath);
                    slider.ImageName = sliderImage.FileName;
                    unitOfWork.SliderService.InsertSlider(slider);
                    unitOfWork.save();
                    return RedirectToAction("Index");
                }
            }

            return View(slider);
        }

        public ActionResult Edit(int id)
        {
            return View(unitOfWork.SliderService.GetSliderById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider, HttpPostedFileBase sliderImage)
        {
            if (ModelState.IsValid)
            {
                if (sliderImage != null)
                {
                    sliderImage.AddImageToServer(sliderImage.FileName, ImagePath.SliderOriginalServerPath, 150, 150, ImagePath.SliderThumbServerPath, slider.ImageName);
                    slider.ImageName = sliderImage.FileName;
                }

                unitOfWork.SliderService.EditSlider(slider);
                unitOfWork.save();

                return RedirectToAction("Index");
            }

            return View(slider);
        }

        public ActionResult Delete(int id)
        {
            var slider = unitOfWork.SliderService.GetSliderById(id);

            if (slider != null)
            {
                slider.IsDelete = true;
                unitOfWork.save();
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Return(int id)
        {
            var slider = unitOfWork.SliderService.GetSliderById(id);

            if (slider != null)
            {
                slider.IsDelete = false;
                unitOfWork.save();
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }
    }
}