namespace IoC
{
    using System;
    using System.Collections.Generic;
    using Interface;
    using Microsoft.Extensions.DependencyInjection;

    public class IoCResolver : IIoCResolver
    {
        // Static
        private static IoCResolver _instance;
        public static IoCResolver Instance => _instance ?? throw new Exception(nameof(IoCResolver));
        public static void Initialize(IServiceProvider serviceProvider) { _instance = new IoCResolver(serviceProvider); }

        // Instance
        private readonly IServiceProvider serviceProvider;
        private IoCResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return (T) this.serviceProvider.GetService(typeof(T));
        }
        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>) this.serviceProvider.GetServices(typeof(T));
        }
    }
}
