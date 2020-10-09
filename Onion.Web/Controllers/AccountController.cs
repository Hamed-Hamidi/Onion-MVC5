using System;
using System.Web.Mvc;
using System.Web.Security;
using Onion.Data.Account;
using Onion.Web.UOW;
using Onion.Web.Utilities.Contracts;
using Onion.Web.Utilities.Convertors;
using Onion.Web.ViewModels.Account;

namespace Onion.Web.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork unitOfWork;
        private IEmailSender sender;

        public AccountController(UnitOfWork unitOfWork, IEmailSender sender)
        {
            this.unitOfWork = unitOfWork;
            this.sender = sender;
        }


        [Route("register", Name = "GetRegister")]
        public ActionResult Register()
        {
            return View();
        }

        [Route("register", Name = "PostRegister")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!unitOfWork.UserService.IsExistUserByUserName(register.UserName))
                {
                    if (register.Password == register.RePassword)
                    {
                        var user = new User
                        {
                            UserName = register.UserName,
                            Email = register.Email,
                            Password = register.Password,
                            ActiveCode = Guid.NewGuid().ToString("N")
                        };

                        unitOfWork.UserService.CreateUser(user);

                        unitOfWork.save();

                        var body = RazorConvertors.RenderPartialViewToString("EmailSender", "ActivateEmail", user);

                        sender.Send(register.Email, "فعالسازی حساب کاربری", body);

                        return RedirectToRoute("GetLogin");
                    }

                    ModelState.AddModelError("RePassword", "کلمات عبور مغایرت دارند");

                    return View(register);
                }

                ModelState.AddModelError("UserName", "کاربری با این نام کاربری وجود دارد");

                return View(register);
            }

            return View(register);
        }

        [Route("activate/{id}")]
        public ActionResult ActiveUser(string id)
        {
            var user = unitOfWork.UserService.GetUserByActiveCode(id);

            if (user != null && !user.IsActive)
            {
                user.IsActive = true;
                user.ActiveCode = Guid.NewGuid().ToString("N");
                unitOfWork.save();
                TempData["SuccessActivate"] = "حساب کاربری شما با موفقیت تایید شد";
                return RedirectToRoute("GetLogin");
            }

            TempData["ErrorActivate"] = "کاربری یافت نشد";

            return RedirectToRoute("GetLogin");
        }

        [Route("login", Name = "GetLogin")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("login", Name = "PostLogin")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = unitOfWork.UserService.GetUserByUserName(login.UserName);

                if (user != null)
                {
                    if (user.Password == login.Password)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);

                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("UserName", "نام کاربری و یا کلمه عبور اشتباه است");
                    return View(login);
                }

                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                return View(login);
            }

            return View(login);
        }

        [Route("sign-out",Name = "SignOut")]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToRoute("GetLogin");
        }
    }
}