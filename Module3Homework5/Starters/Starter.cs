using Module3Homework5.Providers;

namespace Module3Homework5.Starters
{
    public static class Starter
    {
        public  static void Run()
        {
            FileProvider fileProvider = new ();
            var i = fileProvider.ConcatTwoStringsAsync().Result;
            Console.WriteLine(i);
            
        }
    }
}
