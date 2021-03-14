namespace ProcessManager.Process.Application._IoCInstaller
{
    using Core.CQRS;
    using Core.DDD;
    using Core.IoC.Interface;
    using Core.Patterns;
    using Domain.Process.Models;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Process.AppServices;
    using Process.AppServices.Impl;
    using Process.Converters;
    using Process.Enums;
    using Process.Handlers;
    using Process.Models;
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
            this.RegisterConverters(services);
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

        private void RegisterConverters(IServiceCollection services)
        {
            services.AddScoped<IConverter<Domain.Process.Enums.ProcessStatus, ProcessStatus>, ProcessStatusConverter>();
            services.AddScoped<IConverter<Process, ProcessDto>, ProcessConverter>();
        }
    }
}
