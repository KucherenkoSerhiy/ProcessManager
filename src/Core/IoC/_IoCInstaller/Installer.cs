namespace IoC._IoCInstaller
{
    using Interface;
    using Logger;
    using Microsoft.Extensions.DependencyInjection;

    public class Installer: IIoCInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<ILogger, Logger>();
            services.AddSingleton<IIoCResolver, IoCResolver>();
        }
    }
}
