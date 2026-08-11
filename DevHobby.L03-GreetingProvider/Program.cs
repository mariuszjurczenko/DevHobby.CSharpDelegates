using System;

namespace BeginnerDelegateReturnValue;

public delegate string GreetingProvider();

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== ASYSTENT NAGŁÓWKA APLIKACJI ===\n");


        GreetingProvider provider = GetMorningGreeting;
        string message = provider();
        Console.WriteLine($"[7:00  - UI]: {message}");


        provider = GetEveningGreeting;
        message = provider();
        Console.WriteLine($"[20:00 - UI]: {message}");


        provider = () => "Sto lat! Masz dziś urodziny!";
        Console.WriteLine($"[00:01 - UI]: {provider()}");
    }

    private static string GetMorningGreeting()
    {
        return "Dzień dobry! Gotowy na nowy dzień?";
    }

    private static string GetEveningGreeting()
    {
        return "Dobry wieczór! Czas odpocząć od kodu.";
    }
}
