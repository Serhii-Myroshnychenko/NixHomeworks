using Module3Homework5.Configuration;
using Module3Homework5.Providers;

namespace Module3Homework5.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            FileProvider fileProvider = new (new ConfigurationManager());
            Console.WriteLine(fileProvider.ConcatTwoStringsAsync().Result);
        }
    }
}
