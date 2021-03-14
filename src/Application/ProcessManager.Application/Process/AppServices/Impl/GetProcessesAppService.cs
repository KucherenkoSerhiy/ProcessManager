namespace ProcessManager.Process.Application.Process.AppServices.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Patterns;
    using Domain.Process.Models;
    using Domain.Process.Services;
    using Models;

    public class GetProcessesAppService: IGetProcessesAppService
    {
        private readonly IProcessContainer processContainer;
        private readonly IConverter<Process, ProcessDto> processConverter;

        public GetProcessesAppService(IProcessContainer processContainer, IConverter<Process, ProcessDto> processConverter)
        {
            this.processContainer = processContainer;
            this.processConverter = processConverter;
        }

        public IEnumerable<ProcessDto> Get()
        {
            var domainResponse = this.processContainer.GetAll();
            var response = domainResponse.Select(x => this.processConverter.Convert(x));
            return response;
        }
    }
}
