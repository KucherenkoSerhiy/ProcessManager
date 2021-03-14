namespace ProcessManager.Process.Domain.Process.Models
{
    using System;
    using System.Collections.Generic;
    using Core.DDD;
    using Core.NativeObjects.Extensions;
    using Enums;

    public class Process: AggregateRoot
    {
        internal Process(){}

        public override string Id => $"{this.Name}{this.Status}{this.CreationDate}".EncodeHexadecimal();
        public string Name { get; set; }
        public ProcessStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public object Data { get; set; }
        public IEnumerable<string> Logs { get; set; }
    }
}
