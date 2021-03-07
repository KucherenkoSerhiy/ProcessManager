namespace ProcessManager.Domain.Process.Models
{
    using DDD;
    using Enums;

    public class ProcessLog : ValueObject
    {
        public SubProcessStatus Status { get; set; }
        public string Description { get; set; }
    }
}
