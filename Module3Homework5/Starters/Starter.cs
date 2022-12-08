using Module3Homework5.Configuration;
using Module3Homework5.Providers;
using Module3Homework5.Utils;

namespace Module3Homework5.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            FileProvider fileProvider = new (new ConfigurationManager());
            var result = StringsHandler.ConcatTwoStrings(fileProvider.GetHelloFromFileAsync, fileProvider.GetWorldFromFileAsync).Result;

            Console.WriteLine(result);
        }
    }
}
