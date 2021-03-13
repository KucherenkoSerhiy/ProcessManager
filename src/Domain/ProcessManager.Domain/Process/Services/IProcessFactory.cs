namespace ProcessManager.Domain.Process.Services
{
    using Models;

    internal interface IProcessFactory
    {
        Process Create(string name, object data);
    }
}