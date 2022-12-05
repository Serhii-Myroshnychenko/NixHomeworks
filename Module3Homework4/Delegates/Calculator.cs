namespace Module3Homework4.Delegates
{
    public class Calculator
    {
        public delegate double CalculatorHandler (double first, double second);
        public event CalculatorHandler? Compute;
        public double CurrentSum { get; set; }
        public Calculator()
        {
            Compute += GetSumOfTwoNumbers;
            Compute += GetSumOfTwoNumbers;
        }
        public double GetSumOfTwoNumbers(double first, double second)
        {
            Console.WriteLine("here");
            return first + second;
           
        }
        public void GetSum()
        {
            CurrentSum += Compute!.Invoke(2, 2);
            Console.WriteLine("CurrentSum: " + CurrentSum);
        }
        //public  double GetSomeResult(CalculatorHandler calculatorHandler)
        //{
        //    try
        //    {
        //        var sum = calculatorHandler.Invoke;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}
