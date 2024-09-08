Console.WriteLine("Vänligen mata in en text:");
var input = Console.ReadLine();
Console.WriteLine("".PadLeft(input.Length, '*'));
var numbersAsStrings = GetNumberStrings(input);
PrintInputWithNumbersHighlighted(input, numbersAsStrings);
Console.WriteLine();
Console.WriteLine(GetTotalSum(numbersAsStrings));

static void PrintInputWithNumbersHighlighted(string input,  List<string> numbersAsStrings)
{
    for (int i = 0; i < numbersAsStrings.Count; i++)
    {
        int firstIndex = input.IndexOf(numbersAsStrings[i]);
        int lastIndex = input.IndexOf(numbersAsStrings[i]) + numbersAsStrings[i].Length - 1;
        
        for (int j = 0; j < input.Length; j++)
        {
            
            if (j == firstIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(input[j]);
            }
            else if (j == lastIndex)
            {
                Console.Write(input[j]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write(input[j]);
            }
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
    }
}

static List<string> GetNumberStrings(string input)
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

static long GetTotalSum(List<string> numbersAsStrings)
{
    long sum = 0;
    foreach (var item in numbersAsStrings)
    {
        var asInteger = long.Parse(item);
        sum += asInteger;
        
    }
    return sum;
}