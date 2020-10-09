using System.Web.Mvc;
using Onion.Web.UOW;

namespace Onion.Web.Controllers
{
    public class ValidateController : Controller
    {
        private UnitOfWork unitOfWork;

        public ValidateController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult IsExistUserByEmail(string Email)
        {
            return Json(!unitOfWork.UserService.IsExistUserByEmail(Email), JsonRequestBehavior.AllowGet);
        }
    }
}