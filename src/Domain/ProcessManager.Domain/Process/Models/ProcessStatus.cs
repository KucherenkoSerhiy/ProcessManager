namespace ProcessManager.Domain.Process.Models
{
    using DDD;

    public class ProcessStatus : ValueObject
    {
        public int ItemsTotal { get; set; }
        public int ItemsProcessed { get; set; }
        public int ItemsFailed { get; set; }
    }
}
