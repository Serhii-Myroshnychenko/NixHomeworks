using Module3Homework7.Contracts;
using Module3Homework7.Utils;

namespace Module3Homework7.Services
{
    public class FileHandler : IFileHandler
    {
        public Task WriteDataToFileAsync(string path,string[] data)
        {
            return Task.Run(async () => await File.WriteAllTextAsync(path + ".txt", LogsConverter.ConvertLogs(data)));
            //await File.WriteAllTextAsync(path + ".txt",LogsConverter.ConvertLogs(data));
        }
    }
}
