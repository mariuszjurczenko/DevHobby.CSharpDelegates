using System;

namespace BeginnerDelegateReturnValue;

// KROK 1: DEFINIUJESZ
// Nasz delegat przechowuje funkcje, które nie przyjmują argumentów, ale ZWRACAJĄ tekst (string).
public delegate string GreetingProvider();

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== ASYSTENT NAGŁÓWKA APLIKACJI ===\n");

        // KROK 2: PRZYPISUJESZ — bez nawiasów (jak w odcinkach 1 i 2)
        GreetingProvider provider = GetMorningGreeting;

        // KROK 3: WYWOŁUJESZ — i po raz pierwszy ODBIERASZ WYNIK
        // Wywołujemy delegat i zapisujemy zwrócony tekst do zmiennej!
        string message = provider();
        Console.WriteLine(message);
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

// NOWOŚĆ W TYM ODCINKU:
// W odcinku 1 i 2 delegat był ROZKAZEM, "zrób coś".
// Tutaj jest PYTANIEM, "daj mi tekst" i odpowiedź trafia do zmiennej.
