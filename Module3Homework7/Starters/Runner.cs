using Module3Homework7.Services;

namespace Module3Homework7.Starters
{
    public static class Runner
    {
        public static void Run()
        {
            Starter starter = new (new FileHandler());
            starter.AddSomeLogs();
            starter.AddSomeLogs();
        }
    }
}
