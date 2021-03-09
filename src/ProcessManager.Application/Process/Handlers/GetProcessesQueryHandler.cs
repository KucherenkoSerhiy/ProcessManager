namespace ProcessManager.Application.Process.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AppServices;
    using MediatR;
    using Models;
    using Models.Queries;
    using Models.Queries.Responses;

    public class GetProcessesQueryHandler: IRequestHandler<GetProcessesQuery, GetProcessesQueryResponse>
    {
        private readonly IGetProcessesAppService getProcessesAppService;

        public GetProcessesQueryHandler(IGetProcessesAppService getProcessesAppService)
        {
            this.getProcessesAppService = getProcessesAppService;
        }

        public Task<GetProcessesQueryResponse> Handle(GetProcessesQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            var response = new GetProcessesQueryResponse
            {
                Processes = this.getProcessesAppService.Get().ToList()
            };
            return Task.FromResult(response);
        }
    }
}
