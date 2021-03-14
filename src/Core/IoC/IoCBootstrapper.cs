namespace IoC
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Interface;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoCBootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            ExecuteInstallers(services);
            IoCResolver.Initialize(services.BuildServiceProvider());
        }

        private static void ExecuteInstallers(IServiceCollection services)
        {
            var assemblies = new List<Assembly>();
            var assemblyPaths = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
            foreach (string assemblyPath in assemblyPaths)
            {
                var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
                assemblies.Add(assembly);
            }
            
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
