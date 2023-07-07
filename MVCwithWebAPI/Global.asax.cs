using MVCwithWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;
using Unity.AspNet.WebApi;

namespace MVCwithWebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Create Dependancy Resolover
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();

            //DR for MVC Controller
            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(container));

            //dr for webapi controller
            //GlobalConfiguration.Configuration.DependencyResolver = Unity.WebApi.UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityHierarchicalDependencyResolver(container);
        }
    }
}
