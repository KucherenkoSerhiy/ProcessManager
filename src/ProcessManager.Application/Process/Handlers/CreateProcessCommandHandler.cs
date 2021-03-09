namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServices.Impl;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class CreateProcessCommandHandler: IRequestHandler<CreateProcessCommand, CommandResponse>
    {
        private readonly CreateProcessAppService createProcessAppService;

        public CreateProcessCommandHandler(CreateProcessAppService createProcessAppService)
        {
            this.createProcessAppService = createProcessAppService;
        }

        public Task<CommandResponse> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            this.createProcessAppService.Create(request.Process);
            return Task.FromResult(new CommandResponse());
        }
    }
}
