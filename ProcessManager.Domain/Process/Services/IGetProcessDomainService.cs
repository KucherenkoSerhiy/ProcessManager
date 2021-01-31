namespace ProcessManager.Domain.Process.Services
{
    using Models;

    public interface IGetProcessDomainService
    {
        Process GetById(string processId);
    }
}