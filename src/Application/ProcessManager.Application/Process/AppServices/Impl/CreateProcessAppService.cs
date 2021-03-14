namespace ProcessManager.Application.Process.AppServices.Impl
{
    using Domain.Process.Models;
    using Domain.Process.Services;
    using Models;
    using Patterns;

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
