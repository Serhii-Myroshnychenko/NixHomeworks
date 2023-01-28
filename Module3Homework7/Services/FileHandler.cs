using Module3Homework7.Contracts;
using Module3Homework7.Utils;

namespace Module3Homework7.Services
{
    public class FileHandler : IFileHandler
    {
        public async Task WriteDataToFileAsync(string path,string[] data)
        {
            await Task.Run(async () => await File.WriteAllTextAsync(path +Guid.NewGuid() + ".txt", LogsConverter.ConvertLogs(data)));
        }
    }
}
