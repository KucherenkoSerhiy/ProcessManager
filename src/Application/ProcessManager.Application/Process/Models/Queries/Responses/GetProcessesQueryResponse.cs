namespace ProcessManager.Process.Application.Process.Models.Queries.Responses
{
    using System.Collections.Generic;

    public class GetProcessesQueryResponse
    {
        public List<ProcessDto> Processes { get; set; }
    }
}
