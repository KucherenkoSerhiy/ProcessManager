﻿namespace ProcessManager.Process.Application.Process.Models.Commands
{
    using System.Collections.Generic;
    using Core.CQRS;
    using Core.DDD;
    using Core.IoC;
    using MediatR;

    public class UpdateProcessCommand: IRequest<CommandResponse>
    {
        private readonly IEnumerable<IValidator<UpdateProcessCommand>> validators;
        public ProcessDto Process { get; set; }

        public UpdateProcessCommand() : this(IoCResolver.Instance.ResolveAll<IValidator<UpdateProcessCommand>>()){}

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
