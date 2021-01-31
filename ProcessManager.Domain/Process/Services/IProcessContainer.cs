namespace ProcessManager.Domain.Process.Services
{
    using Models;

    public interface IProcessContainer
    {
        void Add(Process process);
    }
}