using Module3Homework3.Delegates;

namespace Module3Homework3.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            Class1 class1 = new ();
            Class2 class2 = new ();

            var delegateForResult = class2.Calc(3, 3);
            class1.ClassDelegate!(delegateForResult(2));
        }
    }
}
