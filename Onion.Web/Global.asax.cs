using System.Web.Mvc;
using System.Web.Routing;
using Onion.Web.IOC;

namespace Onion.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectController());
        }
    }
}
