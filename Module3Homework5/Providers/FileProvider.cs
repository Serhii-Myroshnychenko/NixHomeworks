using Module3Homework5.Contracts;

namespace Module3Homework5.Providers
{
    public class FileProvider : IFileProvider
    {
        private readonly string _path;
        public FileProvider(IPathProvider provider)
        {
            _path = provider.GetPath();
        }

        public async Task<string> GetHelloFromFileAsync()
        {
            return await File.ReadAllTextAsync(_path + "hello.txt");
        }

        public async Task<string> GetWorldFromFileAsync()
        {
            return await File.ReadAllTextAsync(_path + "world.txt");
        }
    }
}
