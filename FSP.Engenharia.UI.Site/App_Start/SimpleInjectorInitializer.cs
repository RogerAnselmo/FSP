[assembly: WebActivator.PostApplicationStartMethod(typeof(FSP.Engenharia.UI.Site.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace FSP.Engenharia.UI.Site.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using FSP.Engengaria.Core.Infra.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}