namespace ProcessManager.Application.Process.Models.Commands
{
    using CQRS;
    using MediatR;

    public class CreateProcessCommand: IRequest<CommandResponse>
    {
        public ProcessDto Process { get; set; }
    }
}
