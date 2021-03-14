namespace ProcessManager.Process.Application.Process.AppServices
{
    using Models;

    public interface IUpdateProcessAppService
    {
        void Update(ProcessDto request);
    }
}