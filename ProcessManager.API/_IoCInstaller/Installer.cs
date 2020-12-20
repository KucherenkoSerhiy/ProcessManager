namespace ProcessManager.API._IoCInstaller
{
    using Dummy;
    using Dummy.Impl;
    using IoC.Interface;
    using Microsoft.Extensions.DependencyInjection;

    public class Installer: IIoCInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<IDummy, Dummy>();
        }
    }
}
