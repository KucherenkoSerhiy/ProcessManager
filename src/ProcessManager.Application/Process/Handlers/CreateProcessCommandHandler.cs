namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class CreateProcessCommandHandler: IRequestHandler<CreateProcessCommand, CommandResponse>
    {
        public Task<CommandResponse> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            var response = new CommandResponse
            {
                Data = "data"
            };
            return Task.FromResult(response);
        }
    }
}
