namespace ProcessManager.Application.Process.Models
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class ProcessDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ProcessStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public object Data { get; set; }
        public IEnumerable<string> Logs { get; set; }
    }
}
