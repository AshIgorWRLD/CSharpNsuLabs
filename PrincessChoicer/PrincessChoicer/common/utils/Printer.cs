namespace PrincessChoicer.common.utils;

public static class Printer
{
    public static void PrintResultToConsole(string result)
    {
        Console.WriteLine(result);
    }

    public static void PrintResultToFile(string result)
    {
        using StreamWriter file = new("result.txt");
        file.WriteLineAsync(result);
    }
}