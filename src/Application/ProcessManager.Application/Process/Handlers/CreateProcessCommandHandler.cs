namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServices;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class CreateProcessCommandHandler: IRequestHandler<CreateProcessCommand, CommandResponse>
    {
        private readonly ICreateProcessAppService createProcessAppService;

        public CreateProcessCommandHandler()
        {
            this.createProcessAppService = createProcessAppService;
        }

        public CreateProcessCommandHandler(ICreateProcessAppService createProcessAppService)
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
