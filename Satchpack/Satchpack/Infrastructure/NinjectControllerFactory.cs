using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;

namespace Satchpack.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // The object that is used to communicate with Ninject components.
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        /// <summary>
        /// Handles the requests of the MVC Framework to return the appropriate controller.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType">The concrete controller class name.</param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        /// <summary>
        /// Binds interfaces to their respective concrete implementations.
        /// </summary>
        private void AddBindings()
        {
        }
    }
}