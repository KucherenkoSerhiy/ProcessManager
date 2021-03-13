namespace ProcessManager.Application.Process.Models.Commands
{
    using System.Collections.Generic;
    using CQRS;
    using DDD;
    using MediatR;

    public class DeleteProcessCommand : IRequest<CommandResponse>
    {
        private readonly IEnumerable<IValidator<DeleteProcessCommand>> validators;
        public string Id { get; set; }

        public DeleteProcessCommand(IEnumerable<IValidator<DeleteProcessCommand>> validators)
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
