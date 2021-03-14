namespace ProcessManager.Process.Application.Process.AppServices.Impl
{
    using Core.Patterns;
    using Domain.Process.Models;
    using Domain.Process.Services;
    using Models;

    public class CreateProcessAppService: ICreateProcessAppService
    {
        private readonly IProcessContainer processContainer;
        private readonly IConverter<Process, ProcessDto> processConverter;

        public CreateProcessAppService(IProcessContainer processContainer, IConverter<Process, ProcessDto> processConverter)
        {
            this.processContainer = processContainer;
            this.processConverter = processConverter;
        }

        public void Create(ProcessDto request)
        {
            var domainRequest = this.processConverter.ConvertBack(request);
            this.processContainer.Add(domainRequest);
        }
    }
}
