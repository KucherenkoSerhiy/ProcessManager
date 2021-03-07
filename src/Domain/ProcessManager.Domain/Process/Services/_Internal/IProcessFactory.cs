namespace ProcessManager.Domain.Process.Services._Internal
{
    using System.Collections.Generic;
    using Enums;
    using Models;

    internal interface IProcessFactory
    {
        Process Instantiate(JobType type, IEnumerable<string> data);
    }
}