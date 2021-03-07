namespace ProcessManager.Application._IoCInstaller
{
    using IoC.Interface;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Process.Handlers;
    using Process.Models.Queries;
    using Process.Models.Queries.Responses;

    public class Installer: IIoCInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetProcessQuery, GetProcessQueryResponse>, GetProcessQueryHandler>();
            services.AddScoped<IRequestHandler<GetProcessesQuery, GetProcessesQueryResponse>, GetProcessesQueryHandler>();
        }
    }
}
