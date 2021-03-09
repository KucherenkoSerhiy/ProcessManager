namespace ProcessManager.Application.Process.Handlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Models;
    using Models.Queries;
    using Models.Queries.Responses;

    public class GetProcessesQueryHandler: IRequestHandler<GetProcessesQuery, GetProcessesQueryResponse>
    {
        public Task<GetProcessesQueryResponse> Handle(GetProcessesQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            var response = new GetProcessesQueryResponse
            {
                Processes = new List<ProcessDto>
                {
                    new ProcessDto{ProcessId = "1"},
                    new ProcessDto{ProcessId = "2"},
                    new ProcessDto{ProcessId = "54"}
                }
            };
            return Task.FromResult(response);
        }
    }
}
