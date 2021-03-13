namespace ProcessManager.Application.Process.Converters
{
    using Domain.Process.Models;
    using Enums;
    using Models;
    using Patterns;

    public class ProcessConverter: IConverter<Process, ProcessDto>
    {
        private readonly IConverter<Domain.Process.Enums.ProcessStatus, ProcessStatus> processStatusConverter;

        public ProcessConverter(IConverter<Domain.Process.Enums.ProcessStatus, ProcessStatus> processStatusConverter)
        {
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
            return new Process
            {
                CreationDate = value.CreationDate,
                Data = value.Data,
                Logs = value.Logs,
                Name = value.Name,
                Status = this.processStatusConverter.ConvertBack(value.Status)
            };
        }
    }
}
