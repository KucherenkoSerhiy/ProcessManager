namespace IoC
{
    using System;
    using System.Linq;
    using Interface;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoCBootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            ExecuteInstallers(services);
        }

        private static void ExecuteInstallers(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(s => s.GetTypes());
            var installers = types.Where(p => typeof(IIoCInstaller).IsAssignableFrom(p) && !p.IsInterface);

            foreach (var type in installers)
            {
                var instance = (IIoCInstaller) Activator.CreateInstance(type);
                instance.Install(services);
            }
        }
    }
}
