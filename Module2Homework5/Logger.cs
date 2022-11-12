using Module2Homework5.Base;

namespace Module2Homework5
{
    public class Logger
    {
        private static readonly object _lock = new object();
        private Logger()
        {
        }

        public static Logger LoggerInstance { get; private set; } = GetLogger();

        public static Logger GetLogger()
        {
            if (LoggerInstance == null)
            {
                lock (_lock)
                {
                    if (LoggerInstance == null)
                    {
                        LoggerInstance = new Logger();
                    }
                }
            }

            return LoggerInstance;
        }

        public void WriteLogToFile(LogTypes type, string message)
        {

        }
    }
}
