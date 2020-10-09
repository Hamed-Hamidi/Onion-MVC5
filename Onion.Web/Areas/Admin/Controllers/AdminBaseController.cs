using System.Web.Mvc;
using Onion.Web.Utilities.Security;

namespace Onion.Web.Areas.Admin.Controllers
{
    [PermissionChecker("Admin")]
    public class AdminBaseController : Controller { }
}