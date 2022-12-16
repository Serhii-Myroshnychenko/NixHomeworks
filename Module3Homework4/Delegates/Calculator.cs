namespace Module3Homework4.Delegates
{
    public class Calculator
    {
        public delegate void CalculatorHandler (double first, double second);
        public event CalculatorHandler? Compute;
        public double CurrentSum { get; set; }
        public Calculator()
        {
            Compute += GetSumOfTwoNumbers;
            Compute += GetSumOfTwoNumbers;
        }
        public void GetSumOfTwoNumbers(double first, double second)
        {
            CurrentSum += first + second;
        }
        public void GetTotalSum(double first, double second)
        {
            try
            {
                Compute!.Invoke(first,second);
                Console.WriteLine("Total sum: " + CurrentSum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
