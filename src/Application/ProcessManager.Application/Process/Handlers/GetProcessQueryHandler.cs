namespace ProcessManager.Process.Application.Process.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using AppServices;
    using MediatR;
    using Models.Queries;
    using Models.Queries.Responses;

    public class GetProcessQueryHandler: IRequestHandler<GetProcessQuery, GetProcessQueryResponse>
    {
        private readonly IGetProcessAppService getProcessAppService;

        public GetProcessQueryHandler(IGetProcessAppService getProcessAppService)
        {
            this.getProcessAppService = getProcessAppService;
        }

        public Task<GetProcessQueryResponse> Handle(GetProcessQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            var response = new GetProcessQueryResponse
            {
                Process = this.getProcessAppService.Get(request.Id)
            };
            return Task.FromResult(response);
        }
    }
}
