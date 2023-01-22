﻿using Module3Homework7.Configurations;
using Module3Homework7.Contracts;

namespace Module3Homework7.Loggers
{
    public class Logger
    {
        public delegate Task LogsHandler();
        public event LogsHandler? Notify;

        private static readonly object _lock = new();
        private string[] _logs;
        private int _number;
        private ConfigurationHandler _configuration;
        private Logger()
        {
            _logs = Array.Empty<string>();
            _configuration = new ();
            _number = _configuration.GetCountOfLogs();
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
        public void AddToLogs()
        {
            string[] logs = new string[_logs.Length + 1];
            for (int i = 0; i < logs.Length - 1; i++)
            {
                logs[i] = _logs[i];
            }

            logs[^1] = "Time: " + DateTime.Now;
            _logs = logs;
            if(_logs.Length % _number == 0)
            {
                Notify!.Invoke();
            }
        }
        public async Task WriteLogsToFileAsync(IFileHandler fileHandler) => await fileHandler.WriteDataToFileAsync(_configuration.GetPath() + DateTime.Now,_logs);
    }
}
