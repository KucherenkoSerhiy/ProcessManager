namespace ProcessManager.Application._IoCInstaller
{
    using CQRS;
    using DDD;
    using IoC.Interface;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Process.AppServices;
    using Process.AppServices.Impl;
    using Process.Handlers;
    using Process.Models.Commands;
    using Process.Models.Queries;
    using Process.Models.Queries.Responses;
    using Process.Validators;

    public class Installer: IIoCInstaller
    {
        public void Install(IServiceCollection services)
        {
            this.RegisterHandlers(services);
            this.RegisterAppServices(services);
            this.RegisterValidators(services);
        }

        private void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetProcessQuery, GetProcessQueryResponse>, GetProcessQueryHandler>();
            services.AddScoped<IRequestHandler<GetProcessesQuery, GetProcessesQueryResponse>, GetProcessesQueryHandler>();
            services.AddScoped<IRequestHandler<CreateProcessCommand, CommandResponse>, CreateProcessCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProcessCommand, CommandResponse>, UpdateProcessCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProcessCommand, CommandResponse>, DeleteProcessCommandHandler>();
        }

        private void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IGetProcessAppService, GetProcessAppService>();
            services.AddScoped<IGetProcessesAppService, GetProcessesAppService>();
            services.AddScoped<ICreateProcessAppService, CreateProcessAppService>();
            services.AddScoped<IUpdateProcessAppService, UpdateProcessAppService>();
            services.AddScoped<IDeleteProcessAppService, DeleteProcessAppService>();
        }

        private void RegisterValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<GetProcessQuery>, GetProcessQueryValidator>();
            services.AddScoped<IValidator<GetProcessesQuery>, GetProcessesQueryValidator>();
            services.AddScoped<IValidator<CreateProcessCommand>, CreateProcessCommandValidator>();
            services.AddScoped<IValidator<UpdateProcessCommand>, UpdateProcessCommandValidator>();
            services.AddScoped<IValidator<DeleteProcessCommand>, DeleteProcessCommandValidator>();
        }
    }
}
