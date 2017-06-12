using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCConfig.RegisterDependencies();
        }
    }

    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes()
                .Where(t => t.Name.EndsWith("DataProviders"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes()
                .Where(t => t.Name.EndsWith("Services"))
                .AsImplementedInterfaces()
                .InstancePerRequest();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
