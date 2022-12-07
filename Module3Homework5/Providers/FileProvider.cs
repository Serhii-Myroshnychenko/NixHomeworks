using Module3Homework5.Contracts;

namespace Module3Homework5.Providers
{
    public class FileProvider : IFileProvider
    {
        public async Task<string> GetHelloFromFileAsync()
        {
            return await File.ReadAllTextAsync("hello.txt");
        }

        public async Task<string> GetWorldFromFileAsync()
        {
            return await File.ReadAllTextAsync("world.txt");
        }
        public async Task<string> ConcatTwoStringsAsync()
        {
            Task<string> first = GetHelloFromFileAsync();
            Task<string> second = GetWorldFromFileAsync();

            var result = await Task.WhenAll(first, second);

            string res = string.Empty;
            foreach(var i in result)
            {
                res += i;
            }
            return res;

        }
    }
}
