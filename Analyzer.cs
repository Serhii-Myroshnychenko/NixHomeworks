namespace Task4
{
    public static class Analyzer
    {
        private static readonly string[] _alphabet = { "A", "b", "c", "D", "E", "f", "g", "H", "I", "J", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public static int GetArraySize()
        {
            int length;
            do
            {
                Console.WriteLine("Enter the array size");
                if (int.TryParse(Console.ReadLine(), out length) && length > 0)
                {
                    break;
                }

                Console.WriteLine("Invalid value");
            }
            while (true);
            return length;
        }

        public static int[] InitializeArray(int length, int minValue, int maxValue)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = new Random().Next(minValue, maxValue + 1);
            }

            return array;
        }

        public static Tuple<int[], int[]> GetArraysWithEvenAndOddNumbers(int[] numbers)
        {
            int indexOfArrayWithEvenNumbers = 0;
            int indexOfArrayWithOddNumbers = 0;

            int[] evenNumbers = new int[numbers.Length];
            int[] oddNumbers = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsEvenNumber(numbers[i]))
                {
                    evenNumbers[indexOfArrayWithEvenNumbers++] = numbers[i];
                }
                else
                {
                    oddNumbers[indexOfArrayWithOddNumbers++] = numbers[i];
                }
            }

            Array.Resize(ref evenNumbers, indexOfArrayWithEvenNumbers);
            Array.Resize(ref oddNumbers, indexOfArrayWithOddNumbers);

            return new Tuple<int[], int[]>(evenNumbers, oddNumbers);
        }

        public static string[] ReplaceNumbersWithLetters(int[] numbers)
        {
            string[] letters = new string[numbers.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = _alphabet[numbers[i] - 1];
            }

            return letters;
        }

        public static void PrintArrayWithGreatestNumberOfLettersInUppercase(string[] first, string[] second)
        {
            int numberOfUppercaseLettersInFirstArray = GetNumberOfLettersInUppercase(first);
            int numberOfUppercaseLettersInSecondArray = GetNumberOfLettersInUppercase(second);

            if (numberOfUppercaseLettersInFirstArray > numberOfUppercaseLettersInSecondArray)
            {
                PrintArray(first);
            }
            else if (numberOfUppercaseLettersInFirstArray < numberOfUppercaseLettersInSecondArray)
            {
                PrintArray(second);
            }
            else
            {
                Console.WriteLine("Number is the same");
                PrintArray(first);
                PrintArray(second);
            }
        }

        public static void PrintArray(int[] numbers) => Console.WriteLine(string.Join(" ", numbers));
        public static void PrintArray(string[] letters) => Console.WriteLine(string.Join(" ", letters));
        private static bool IsEvenNumber(int number) => number % 2 == 0 ? true : false;
        private static int GetNumberOfLettersInUppercase(string[] letters)
        {
            int count = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsUpper(char.Parse(letters[i])))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
