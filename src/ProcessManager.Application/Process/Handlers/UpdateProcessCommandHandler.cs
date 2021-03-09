namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServices;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class UpdateProcessCommandHandler: IRequestHandler<UpdateProcessCommand, CommandResponse>
    {
        private readonly IUpdateProcessAppService updateProcessAppService;

        public UpdateProcessCommandHandler(IUpdateProcessAppService updateProcessAppService)
        {
            this.updateProcessAppService = updateProcessAppService;
        }

        public Task<CommandResponse> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            this.updateProcessAppService.Update(request.Process);
            return Task.FromResult(new CommandResponse());
        }
    }
}
