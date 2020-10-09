using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Onion.Repository.ApplicationContext;
using Onion.Web.UOW;
using Onion.Web.Utilities.Contracts;
using Onion.Web.Utilities.Implementations;

namespace Onion.Web.IOC
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectController()
        {
            ninjectKernel = new StandardKernel();

            Bind();
        }

        private void Bind()
        {
            ninjectKernel.Bind<OnionContext>().To<OnionContext>();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            ninjectKernel.Bind<IEmailSender>().To<EmailSender>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, "not found");
            }

            return (IController)ninjectKernel.Get(controllerType);
        }
    }
}