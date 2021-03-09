namespace ProcessManager.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Models;
    using Models.Queries;
    using Models.Queries.Responses;

    public class GetProcessQueryHandler: IRequestHandler<GetProcessQuery, GetProcessQueryResponse>
    {
        public Task<GetProcessQueryResponse> Handle(GetProcessQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            var response = new GetProcessQueryResponse
            {
                Process = new ProcessDto
                {
                    ProcessId = request.Id
                }
            };
            return Task.FromResult(response);
        }
    }
}
