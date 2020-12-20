namespace Logger
{
    using System.IO;
    using System.Reflection;
    using log4net;
    using log4net.Config;

    public class Logger: ILogger
    {
        private static Logger _instance;
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();

                    // Load configuration
                    var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                    XmlConfigurator.Configure(logRepository, new FileInfo("config/log4net.config"));
                }

                return _instance;
            }
        }

        public void Fatal(string message)
        {
            this.log.Fatal(message);
        }

        public void Error(string message)
        {
            this.log.Error(message);
        }

        public void Warn(string message)
        {
            this.log.Warn(message);
        }

        public void Info(string message)
        {
            this.log.Info(message);
        }

        public void Debug(string message)
        {
            this.log.Debug(message);
        }
    }
}
