namespace Module3Homework3.Delegates
{
    public class Class2
    {
        public Class2()
        {
            DelegateForPow1 = Class1.Pow;
            DelegateForResult1 = Result;
        }

        public delegate double DelegateForPow(double first, double second);
        public delegate bool DelegateForResult(double number);
        public DelegateForPow DelegateForPow1 { get; set; }
        public DelegateForResult DelegateForResult1 { get; set; }
        public double MultiplicationResult { get; private set; }
        public DelegateForResult Calc(double first, double second)
        {
            MultiplicationResult = DelegateForPow1(first, second);
            return DelegateForResult1;
        }

        public bool Result(double number)
        {
            if (MultiplicationResult % number == 0)
            {
                return true;
            }

            return false;
        }
    }
}
