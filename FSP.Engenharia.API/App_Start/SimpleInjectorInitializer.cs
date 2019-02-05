[assembly: WebActivator.PostApplicationStartMethod(typeof(FSP.Engenharia.API.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace FSP.Engenharia.API.App_Start
{
    using FSP.Engengaria.Core.Infra.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using System.Web.Http;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}