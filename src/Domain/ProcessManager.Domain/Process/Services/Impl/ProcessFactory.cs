namespace ProcessManager.Domain.Process.Services.Impl
{
    using Models;

    public class ProcessFactory: IProcessFactory
    {
        public Process Create(string name, object data)
        {
            return new Process
            {
                Name = name,
                Data = data
            };
        }
    }
}
