namespace ProcessManager.Domain.Process.Models
{
    using System;
    using System.Collections.Generic;
    using DDD;
    using Enums;
    using NativeObjects.Extensions;

    public class Process: AggregateRoot
    {
        internal Process(){}

        public override string Id => $"{Name}{Status}{CreationDate}".EncodeHexadecimal();
        public string Name { get; set; }
        public ProcessStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public object Data { get; set; }
        public IEnumerable<string> Logs { get; set; }
    }
}
