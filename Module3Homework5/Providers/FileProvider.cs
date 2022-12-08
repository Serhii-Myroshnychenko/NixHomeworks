using Module3Homework5.Contracts;

namespace Module3Homework5.Providers
{
    public class FileProvider : IFileProvider
    {
        private readonly string _path;
        public FileProvider(IPathProvider provider)
        {
            _path = provider.GetPath();
            Console.WriteLine(_path);
        }

        public async Task<string> GetHelloFromFileAsync()
        {
            return await File.ReadAllTextAsync(_path + "hello.txt");
        }

        public async Task<string> GetWorldFromFileAsync()
        {
            return await File.ReadAllTextAsync(_path + "world.txt");
        }

        public async Task<string> ConcatTwoStringsAsync()
        {
            Task<string> first = GetHelloFromFileAsync();
            Task<string> second = GetWorldFromFileAsync();

            var result = await Task.WhenAll(first, second);
            return result[0] + result[1];
        }
    }
}
