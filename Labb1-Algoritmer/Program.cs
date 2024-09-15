Console.WriteLine("Please enter a text:");
var input = Console.ReadLine();
Console.WriteLine("".PadLeft(input.Length, '*'));
PrintNumberStrings(input);
Console.WriteLine("".PadLeft(input.Length, '*'));
Console.WriteLine($"Total sum: {GetTotalSumOfNumberStrings(input)}");

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
                    Console.Write(input[j+1..input.Length]);
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
}
static long GetTotalSumOfNumberStrings(string input)
{
    long sum = 0;

    for (int i = 0; i < input.Length; i++)
    {
        bool isInteger = Char.IsDigit(input[i]);
        var numberString = "";

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
                    numberString += input[j];
                    long numbersAsInt = long.Parse(numberString);
                    sum += numbersAsInt;
                    break;
                }
                else
                {
                    numberString += input[j];
                }
            }
        }
    }
    return sum;
}
