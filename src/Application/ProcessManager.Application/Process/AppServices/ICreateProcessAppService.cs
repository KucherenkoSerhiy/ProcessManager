namespace ProcessManager.Process.Application.Process.AppServices
{
    using Models;

    public interface ICreateProcessAppService
    {
        void Create(ProcessDto request);
    }
}