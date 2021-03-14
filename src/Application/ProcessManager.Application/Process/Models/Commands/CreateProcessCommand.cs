namespace ProcessManager.Application.Process.Models.Commands
{
    using System.Collections.Generic;
    using CQRS;
    using DDD;
    using IoC;
    using MediatR;

    public class CreateProcessCommand: IRequest<CommandResponse>
    {
        private readonly IEnumerable<IValidator<CreateProcessCommand>> validators;
        public ProcessDto Process { get; set; }

        public CreateProcessCommand() : this(IoCResolver.Instance.ResolveAll<IValidator<CreateProcessCommand>>()){}

        public CreateProcessCommand(IEnumerable<IValidator<CreateProcessCommand>> validators)
        {
            this.validators = validators;
        }

        public void Validate()
        {
            foreach (var validator in this.validators)
            {
                validator.Validate(this);
            }
        }
    }
}
