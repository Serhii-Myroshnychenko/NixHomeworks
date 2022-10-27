using static Task4.Analyzer;

int[] arrayOfNumbers = InitializeArray(GetArraySize(), 1, 26);
Console.WriteLine("Input array:");
PrintArray(arrayOfNumbers);

Tuple<int[], int[]> tuple = GetArraysWithEvenAndOddNumbers(arrayOfNumbers);
int[] evenNumbers = tuple.Item1;
int[] oddNumbers = tuple.Item2;

Console.WriteLine("Even numbers: ");
PrintArray(evenNumbers);
Console.WriteLine("Odd numbers: ");
PrintArray(oddNumbers);

string[] firstArray = ReplaceNumbersWithLetters(oddNumbers);
string[] secondArray = ReplaceNumbersWithLetters(evenNumbers);

Console.WriteLine("The first array (odd numbers): ");
PrintArray(firstArray);
Console.WriteLine("The second array (even numbers): ");
PrintArray(secondArray);

Console.WriteLine("The array with the greatest number of letters in uppercase:");
PrintArrayWithGreatestNumberOfLettersInUppercase(firstArray, secondArray);
