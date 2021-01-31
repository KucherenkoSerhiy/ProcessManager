namespace ProcessManager.Domain.Process.Models
{
    using System.Collections.Generic;
    using DDD;
    using Enums;

    public class Process: AggregateRoot
    {
        public JobType Type { get; set; }
        public IEnumerable<string> Data { get; set; }
        public ProcessStatus Status { get; set; }
        public IEnumerable<ProcessLog> Logs { get; set; }
    }
}
