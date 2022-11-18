using Module2Homework5.Base;
using Module2Homework5.Data;

namespace Module2Homework5.Executors
{
    public class Logger
    {
        private static readonly object _lock = new ();
        private string[] _logs;
        private Logger()
        {
            _logs = Array.Empty<string>();
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

        public void AddToLogs(LogTypes type, string message)
        {
            string[] logs = new string[_logs.Length + 1];
            for (int i = 0; i < logs.Length - 1; i++)
            {
                logs[i] = _logs[i];
            }

            logs[logs.Length - 1] = DateTime.Now + ":" + type + ":" + message;
            _logs = logs;
        }

        public void GetLogs() => Console.WriteLine(string.Join(Environment.NewLine, _logs));
        public void WriteLogsToFile() => FileService.WriteLogsToFile(_logs);
    }
}
