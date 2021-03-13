namespace ProcessManager.Application.Process.Converters
{
    using System;
    using Enums;
    using Patterns;

    public class ProcessStatusConverter : IConverter<Domain.Process.Enums.ProcessStatus, ProcessStatus>
    {
        public ProcessStatus Convert(Domain.Process.Enums.ProcessStatus value)
        {
            switch (value)
            {
                case Domain.Process.Enums.ProcessStatus.Default:
                    return ProcessStatus.Default;
                case Domain.Process.Enums.ProcessStatus.NotStarted:
                    return ProcessStatus.NotStarted;
                case Domain.Process.Enums.ProcessStatus.Running:
                    return ProcessStatus.Running;
                case Domain.Process.Enums.ProcessStatus.Paused:
                    return ProcessStatus.Paused;
                case Domain.Process.Enums.ProcessStatus.Success:
                    return ProcessStatus.Success;
                case Domain.Process.Enums.ProcessStatus.Error:
                    return ProcessStatus.Error;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public Domain.Process.Enums.ProcessStatus ConvertBack(ProcessStatus value)
        {
            switch (value)
            {
                case ProcessStatus.Default:
                    return Domain.Process.Enums.ProcessStatus.Default;
                case ProcessStatus.NotStarted:
                    return Domain.Process.Enums.ProcessStatus.NotStarted;
                case ProcessStatus.Running:
                    return Domain.Process.Enums.ProcessStatus.Running;
                case ProcessStatus.Paused:
                    return Domain.Process.Enums.ProcessStatus.Paused;
                case ProcessStatus.Success:
                    return Domain.Process.Enums.ProcessStatus.Success;
                case ProcessStatus.Error:
                    return Domain.Process.Enums.ProcessStatus.Error;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    }
}
