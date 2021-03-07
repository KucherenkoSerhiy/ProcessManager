namespace ProcessManager.Application.Process.Models.Commands
{
    using CQRS;
    using MediatR;

    public class UpdateProcessCommand: IRequest<CommandResponse>
    {
        public ProcessDto Process { get; set; }
    }
}
