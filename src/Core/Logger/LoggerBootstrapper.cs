namespace ProcessManager.Core.Logger
{
    using System.IO;
    using System.Reflection;
    using System.Xml;

    public static class LoggerBootstrapper
    {
        public static void Initialize()
        {
            var log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("config/log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}
