namespace ProcessManager.Domain.Process.Services
{
    using System.Collections.Generic;

    public interface IRunProcessDomainService
    {
        void Run(IEnumerable<string> Data);
    }
}