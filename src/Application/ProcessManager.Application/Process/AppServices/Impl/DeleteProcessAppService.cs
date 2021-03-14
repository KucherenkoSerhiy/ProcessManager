namespace ProcessManager.Application.Process.AppServices.Impl
{
    using Domain.Process.Services;

    public class DeleteProcessAppService: IDeleteProcessAppService
    {
        private readonly IProcessContainer processContainer;

        public DeleteProcessAppService(IProcessContainer processContainer)
        {
            this.processContainer = processContainer;
        }

        public void Delete(string id)
        {
            this.processContainer.Delete(id);
        }
    }
}
