namespace ProcessManager.Domain.Process.Services
{
    using System.Collections.Generic;
    using Enums;

    public interface IDispatchProcessDomainService
    {
        void Dispatch(JobType type, IEnumerable<string> data);
    }
}