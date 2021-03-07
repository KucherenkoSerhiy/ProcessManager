namespace ProcessManager.Application.Process.Models.Commands
{
    using CQRS;
    using MediatR;

    public class DeleteProcessCommand : IRequest<CommandResponse>
    {
        public string Id { get; set; }
    }
}
