using Module3Homework4.Delegates;
using Module3Homework4.LINQ.Methods;

namespace Module3Homework4.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            Console.WriteLine("Delegates: " + Environment.NewLine);
            Calculator calculator = new ();
            calculator.GetTotalSum(3, 3);

            Console.WriteLine(Environment.NewLine + "LINQ: " + Environment.NewLine);
            Executor.Execute();
        }
    }
}
