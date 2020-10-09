using System.Web.Mvc;
using Onion.Service.DTO.User;
using Onion.Web.UOW;
using Onion.Web.Utilities.Security;

namespace Onion.Web.Areas.Admin.Controllers
{
    [PermissionChecker("ManageUsers")]
    public class UsersController : AdminBaseController
    {
        private IUnitOfWork unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public ActionResult Index(AdminUsersDto filter)
        {
            filter.TakeEntity = 10;

            var users = unitOfWork.UserService.GetUsersByFilter(filter);

            return View(users);
        }

        public ActionResult Edit(int id)
        {
            var user = unitOfWork.UserService.GetUserForEdit(id);

            if (user == null) return HttpNotFound();

            return View(user);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(AdminEditUser editedUser)
        {
            if (!unitOfWork.UserService.IsExistUserByUserName(editedUser.UserName, editedUser.CurrentUserName))
            {
                if (!unitOfWork.UserService.IsExistUserByEmail(editedUser.Email, editedUser.CurrentEmail))
                {
                    var user = unitOfWork.UserService.GetUserByUserId(editedUser.UserId);
                    user.IsActive = editedUser.IsActive;
                    user.UserName = editedUser.UserName;
                    user.Email = editedUser.Email;
                    unitOfWork.UserService.UpdateUser(user);
                    unitOfWork.save();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Email", "ایمیل استفاده شده تکراری میباشد");
            }
            else
            {
                ModelState.AddModelError("UserName", "نام کاربری استفاده شده تکراری میباشد");
            }

            return View(editedUser);
        }

        public ActionResult Delete(int Id)
        {
            var user = unitOfWork.UserService.GetUserByUserId(Id);

            if (user != null)
            {
                user.IsDelete = true;
                unitOfWork.UserService.UpdateUser(user);
                unitOfWork.save();

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Return(int Id)
        {
            var user = unitOfWork.UserService.GetUserByUserId(Id);

            if (user != null)
            {
                user.IsDelete = false;
                unitOfWork.UserService.UpdateUser(user);
                unitOfWork.save();

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }
    }
}