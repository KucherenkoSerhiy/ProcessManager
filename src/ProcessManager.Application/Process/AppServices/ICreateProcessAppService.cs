namespace ProcessManager.Application.Process.AppServices
{
    using Models;

    public interface ICreateProcessAppService
    {
        void Create(ProcessDto request);
    }
}