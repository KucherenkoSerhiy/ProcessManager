namespace ProcessManager.Core.IoC.Interface
{
    using Microsoft.Extensions.DependencyInjection;

    public interface IIoCInstaller
    {
        void Install(IServiceCollection services);
    }
}