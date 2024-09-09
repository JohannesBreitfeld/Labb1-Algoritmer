Console.WriteLine("Please enter a text:");
var input = Console.ReadLine();
Console.WriteLine("".PadLeft(input.Length, '*'));
PrintNumberStrings(input);
Console.WriteLine("".PadLeft(input.Length, '*'));
Console.WriteLine($"Total sum: {GetTotalSumFromListOfNumberStrings(ExtractNumberStringsToList(input))}");

static List<string> ExtractNumberStringsToList(string input)
{
    List<string> numbers = new();

    for (int i = 0; i < input.Length; i++)
    {
        bool isInteger = Char.IsDigit(input[i]);
        var numbersString = "";

        if (isInteger)
        {
            for (int j = i; j < input.Length; j++)
            {
                isInteger = Char.IsDigit(input[j]);
                if (!isInteger)
                {
                    break;
                }
                else if (j != i && input[j] == input[i])
                {
                    numbersString += input[j];
                    numbers.Add(numbersString);
                    break;
                }
                else
                {
                    numbersString += input[j];
                }
            }
        }
    }
    return numbers;
}

static long GetTotalSumFromListOfNumberStrings(List<string> numbersAsStrings)
{
    long sum = 0;
    foreach (var numberString in numbersAsStrings)
    {
        var asInteger = long.Parse(numberString);
        sum += asInteger;
        
    }
    return sum;
}
static void PrintNumberStrings(string input)
{
    for (int i = 0; i < input.Length; i++)
    {
        bool isInteger = Char.IsDigit(input[i]);
        if (isInteger)
        {
            for (int j = i; j < input.Length; j++)
            {
                isInteger = Char.IsDigit(input[j]);
                if (!isInteger)
                {
                    break;
                }
                else if (j != i && input[j] == input[i])
                {
                    Console.Write(input[0..i]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(input[i..(j + 1)]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(input[j..(input.Length - 1)]);
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
}