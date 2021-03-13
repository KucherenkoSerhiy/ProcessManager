namespace ProcessManager.Application.Process.Models.Commands
{
    using System.Collections.Generic;
    using CQRS;
    using DDD;
    using MediatR;

    public class UpdateProcessCommand: IRequest<CommandResponse>
    {
        private readonly IEnumerable<IValidator<UpdateProcessCommand>> validators;
        public ProcessDto Process { get; set; }

        public UpdateProcessCommand(IEnumerable<IValidator<UpdateProcessCommand>> validators)
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
