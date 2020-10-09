using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onion.Web.Controllers
{
    public class EmailSenderController : Controller
    {

        public ActionResult ActivateEmail()
        {
            return PartialView();
        }
    }
}