using System;

public delegate void DisplayMessage(string text);

public class Program
{
    public static void Main()
    {
        DisplayMessage myDelegate = ShowHello;

        myDelegate("Jan");

        myDelegate = ShowGoodbye;
        myDelegate("Jan");
    }

    private static void ShowHello(string name)
    {
        Console.WriteLine($"Cześć, {name}!");
    }

    private static void ShowGoodbye(string name)
    {
        Console.WriteLine($"Do widzenia, {name}!");
    }
}
