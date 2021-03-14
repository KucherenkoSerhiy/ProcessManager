namespace ProcessManager.Application.Process.Models.Queries
{
    using System.Collections.Generic;
    using DDD;
    using IoC;
    using MediatR;
    using Responses;

    public class GetProcessQuery: IRequest<GetProcessQueryResponse>
    {
        private readonly IEnumerable<IValidator<GetProcessQuery>> validators;
        public string Id { get; set; }

        public GetProcessQuery()
        {
            this.validators = IoCResolver.Instance.ResolveAll<IValidator<GetProcessQuery>>();
        }

        public GetProcessQuery(IEnumerable<IValidator<GetProcessQuery>> validators)
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
