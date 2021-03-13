﻿namespace ProcessManager.Application.Process.Models.Queries
{
    using System.Collections.Generic;
    using DDD;
    using MediatR;
    using Responses;

    public class GetProcessesQuery: IRequest<GetProcessesQueryResponse>
    {
        private readonly IEnumerable<IValidator<GetProcessesQuery>> validators;

        public GetProcessesQuery(IEnumerable<IValidator<GetProcessesQuery>> validators)
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