namespace ProcessManager.Process.Domain.Process.Services.Impl
{
    using Models;

    public class ProcessFactory: IProcessFactory
    {
        public Process CreateBlank()
        {
            return new Process();
        }

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
