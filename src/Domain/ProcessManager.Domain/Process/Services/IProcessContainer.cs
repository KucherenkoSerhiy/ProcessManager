namespace ProcessManager.Process.Domain.Process.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IProcessContainer
    {
        Process GetById(string id);
        IEnumerable<Process> GetAll();
        void Add(Process process);
        void Update(Process process);
        void Delete(string id);
    }
}