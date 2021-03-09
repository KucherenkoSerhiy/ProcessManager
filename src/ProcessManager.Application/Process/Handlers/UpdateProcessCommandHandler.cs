namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS;
    using MediatR;
    using Models.Commands;

    public class UpdateProcessCommandHandler: IRequestHandler<UpdateProcessCommand, CommandResponse>
    {
        public Task<CommandResponse> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
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
