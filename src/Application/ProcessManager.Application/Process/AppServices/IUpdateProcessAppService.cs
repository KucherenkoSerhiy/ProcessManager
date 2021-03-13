namespace ProcessManager.Application.Process.AppServices
{
    using Models;

    public interface IUpdateProcessAppService
    {
        void Update(ProcessDto request);
    }
}