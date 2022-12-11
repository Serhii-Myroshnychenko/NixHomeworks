using Module3Homework6.WindowImplementation;

namespace Module3Homework6.Starters
{
    public static class Starter
    {
        public static async Task Run()
        {
            MessageBox messageBox = new ();

            for (int i = 0; i < 10; i++)
            {
                 await messageBox.Open();
            }
        }
    }
}
