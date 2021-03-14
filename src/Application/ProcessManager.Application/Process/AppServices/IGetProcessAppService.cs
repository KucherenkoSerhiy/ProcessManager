namespace ProcessManager.Process.Application.Process.AppServices
{
    using Models;

    public interface IGetProcessAppService
    {
        ProcessDto Get(string id);
    }
}
