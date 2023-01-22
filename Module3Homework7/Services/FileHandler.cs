using Module3Homework7.Contracts;

namespace Module3Homework7.Services
{
    public class FileHandler : IFileHandler
    {
        public async Task WriteDataToFileAsync(string path,string[] data)
        {
            var a = path + ".txt";
            await File.WriteAllTextAsync(a,data.ToString());
        }
    }
}
