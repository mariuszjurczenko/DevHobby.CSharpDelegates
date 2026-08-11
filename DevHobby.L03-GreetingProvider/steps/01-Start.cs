using System;

namespace BeginnerDelegateReturnValue;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== ASYSTENT NAGŁÓWKA APLIKACJI ===\n");

        Console.WriteLine($"[7:00  - UI]: {GetMorningGreeting()}");
        Console.WriteLine($"[20:00 - UI]: {GetEveningGreeting()}");
    }

    // Metoda #1 (brak parametrów, zwraca string)
    private static string GetMorningGreeting()
    {
        return "Dzień dobry! Gotowy na nowy dzień?";
    }

    // Metoda #2 (brak parametrów, zwraca string)
    private static string GetEveningGreeting()
    {
        return "Dobry wieczór! Czas odpocząć od kodu.";
    }
}

// Komponent nagłówka musi znać wszystkie źródła tekstu.
// Dodanie powitania świątecznego = edycja Main().
// Chcemy: 
// Komponent dostaje delegat i pyta go o tekst, nie wiedząc, skąd ten tekst się bierze.
