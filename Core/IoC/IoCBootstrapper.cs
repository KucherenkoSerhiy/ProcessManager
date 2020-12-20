namespace IoC
{
    using System;
    using System.Linq;
    using Enum;
    using Interface;
    using Microsoft.Extensions.DependencyInjection;
    using Windsor;

    public static class IoCBootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            InitializeContainer(services);
            ExecuteInstallers();
        }

        private static void InitializeContainer(IServiceCollection services)
        {
            IoCContainerManager.Container = new WindsorIocContainer(services);
        }

        private static void ExecuteInstallers()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IIoCInstaller).IsAssignableFrom(p) && !p.IsInterface);

            foreach (var type in types)
            {
                var instance = (IIoCInstaller) Activator.CreateInstance(type);
                instance.Install(LifeStyleType.Scoped);
            }
        }
    }
}
