namespace YekanPedia.RoboTele.Proxy
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using DependencyResolver;
    using ControllerFactory;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocInitializer.Initialize();
            ControllerBuilder.Current.SetControllerFactory(new IocControllerFactory());
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            IocInitializer.HttpContextDisposeAndClearAll();
        }
    }
}
