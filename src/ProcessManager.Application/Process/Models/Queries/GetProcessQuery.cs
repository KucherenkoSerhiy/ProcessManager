namespace ProcessManager.Application.Process.Models.Queries
{
    using MediatR;
    using Responses;

    public class GetProcessQuery: IRequest<GetProcessQueryResponse>
    {
        public string Id { get; set; }
    }
}
