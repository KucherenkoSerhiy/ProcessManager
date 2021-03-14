namespace ProcessManager.Process.Domain.Process.Services
{
    using Models;

    public interface IProcessFactory
    {
        Process CreateBlank();
        Process Create(string name, object data);
    }
}