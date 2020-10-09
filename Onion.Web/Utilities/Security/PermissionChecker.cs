using System.Web;
using System.Web.Mvc;
using Onion.Repository.ApplicationContext;
using Onion.Web.UOW;
using Onion.Web.Utilities.Tools;

namespace Onion.Web.Utilities.Security
{
    public class PermissionChecker : AuthorizeAttribute
    {
        private string roleName;

        public PermissionChecker(string roleName)
        {
            this.roleName = roleName;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!UserManager.IsUserAuthenticated()) return false;

            var unitOfWork = new UnitOfWork(new OnionContext());

            return unitOfWork.UserService.HasUserThisPermission(roleName, UserManager.GetCurrentUserName());
        }
    }
}