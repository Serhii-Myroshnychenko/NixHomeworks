using Module3Homework7.Contracts;
using Module3Homework7.Loggers;

namespace Module3Homework7.Starters
{
    public class Starter
    {
        private readonly IFileHandler _fileHandler;
        public Starter(IFileHandler fileHandler)
        {
            Logger.LoggerInstance.Notify += WriteLogsToFileAsync;
            _fileHandler = fileHandler;
        }
        public async Task WriteLogsToFileAsync()
        {
            await Logger.LoggerInstance.WriteLogsToFileAsync(_fileHandler);
        }
        public void AddSomeLogs()
        {
            for(int i = 0; i < 50; i++)
            {
                Logger.LoggerInstance.AddToLogs();
            }
        }
    }
}
