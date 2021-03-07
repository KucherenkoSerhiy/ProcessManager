namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class DeleteProcessCommandHandler: IRequestHandler<DeleteProcessCommand, CommandResponse>
    {
        public Task<CommandResponse> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse
            {
                Data = "data"
            };
            return Task.FromResult(response);
        }
    }
}
