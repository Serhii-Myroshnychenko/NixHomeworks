using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Homework1
{
    public class Logger
    {
        private static readonly object _lock = new object();
        private string[] _logs = new string[0];
        private Logger()
        {
            _logs = new string[0];
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
        public void WriteLogsToFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _logs.Length; i++)
            {
                stringBuilder.AppendLine(_logs[i]);
            }

            File.WriteAllText("log.txt", stringBuilder.ToString());
        }
    }
}
