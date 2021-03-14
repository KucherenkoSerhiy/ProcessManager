namespace ProcessManager.Process.Application.Process.AppServices.Impl
{
    using Core.Patterns;
    using Domain.Process.Models;
    using Domain.Process.Services;
    using Models;

    public class UpdateProcessAppService: IUpdateProcessAppService
    {
        private readonly IProcessContainer processContainer;
        private readonly IConverter<Process, ProcessDto> processConverter;

        public UpdateProcessAppService(IProcessContainer processContainer, IConverter<Process, ProcessDto> processConverter)
        {
            this.processContainer = processContainer;
            this.processConverter = processConverter;
        }

        public void Update(ProcessDto request)
        {
            var domainRequest = this.processConverter.ConvertBack(request);
            this.processContainer.Update(domainRequest);
        }
    }
}
