namespace ProcessManager.Process.Domain.Process._IoCInstaller
{
    using Core.IoC.Interface;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Impl;

    public class Installer: IIoCInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<IProcessFactory, ProcessFactory>();
            services.AddScoped<IProcessContainer, ProcessContainer>();
        }
    }
}
