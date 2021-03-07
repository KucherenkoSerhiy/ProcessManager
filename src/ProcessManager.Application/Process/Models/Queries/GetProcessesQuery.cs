namespace ProcessManager.Application.Process.Models.Queries
{
    using MediatR;
    using Responses;

    public class GetProcessesQuery: IRequest<GetProcessesQueryResponse>
    {
    }
}
