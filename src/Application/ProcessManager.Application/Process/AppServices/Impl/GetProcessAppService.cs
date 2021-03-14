namespace ProcessManager.Process.Application.Process.AppServices.Impl
{
    using Core.Patterns;
    using Domain.Process.Models;
    using Domain.Process.Services;
    using Models;

    public class GetProcessAppService: IGetProcessAppService
    {
        private readonly IProcessContainer processContainer;
        private readonly IConverter<Process, ProcessDto> processConverter;

        public GetProcessAppService(IProcessContainer processContainer, IConverter<Process, ProcessDto> processConverter)
        {
            this.processContainer = processContainer;
            this.processConverter = processConverter;
        }

        public ProcessDto Get(string id)
        {
            var domainResponse = this.processContainer.GetById(id);
            var response = this.processConverter.Convert(domainResponse);
            return response;
        }
    }
}
