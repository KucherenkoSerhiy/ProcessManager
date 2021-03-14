namespace ProcessManager.Application.Process.Converters
{
    using Domain.Process.Models;
    using Domain.Process.Services;
    using Enums;
    using Models;
    using Patterns;

    public class ProcessConverter: IConverter<Process, ProcessDto>
    {
        private readonly IProcessFactory processFactory;
        private readonly IConverter<Domain.Process.Enums.ProcessStatus, ProcessStatus> processStatusConverter;

        public ProcessConverter(IProcessFactory processFactory, 
            IConverter<Domain.Process.Enums.ProcessStatus, ProcessStatus> processStatusConverter)
        {
            this.processFactory = processFactory;
            this.processStatusConverter = processStatusConverter;
        }

        public ProcessDto Convert(Process value)
        {
            return new ProcessDto
            {
                CreationDate = value.CreationDate,
                Data = value.Data,
                Id = value.Id,
                Logs = value.Logs,
                Name = value.Name,
                Status = this.processStatusConverter.Convert(value.Status)
            };
        }

        public Process ConvertBack(ProcessDto value)
        {
            var converted = this.processFactory.CreateBlank();
            converted.Name = value.Name;
            converted.Data = value.Data;
            converted.CreationDate = value.CreationDate;
            converted.Logs = value.Logs;
            converted.Status = this.processStatusConverter.ConvertBack(value.Status);
            return converted;
        }
    }
}
