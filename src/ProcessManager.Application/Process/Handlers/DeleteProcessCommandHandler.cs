namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServices;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class DeleteProcessCommandHandler: IRequestHandler<DeleteProcessCommand, CommandResponse>
    {
        private readonly IDeleteProcessAppService deleteProcessAppService;

        public DeleteProcessCommandHandler(IDeleteProcessAppService deleteProcessAppService)
        {
            this.deleteProcessAppService = deleteProcessAppService;
        }

        public Task<CommandResponse> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            this.deleteProcessAppService.Delete(request.Id);
            return Task.FromResult(new CommandResponse());
        }
    }
}
