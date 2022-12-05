namespace Module3Homework3.Delegates
{
    public class Class1
    {
        public Class1()
        {
            ClassDelegate = Program.Show;
        }

        public delegate void Class1Delegate(bool flag);
        public Class1Delegate? ClassDelegate { get; set; }
        public static double Pow(double firts, double second)
        {
            return firts * second;
        }
    }
}
