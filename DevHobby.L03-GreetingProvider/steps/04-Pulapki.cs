using System;

namespace BeginnerDelegateReturnValue;

public delegate string GreetingProvider();

public class Pulapki
{
    public static void Main()
    {
        GreetingProvider provider = GetMorningGreeting;

        // PUŁAPKA 1 — zignorowanie wyniku
        provider();                     // ✅ kompiluje się, ale tekst przepada
        // Delegat zwracający wartość MOŻNA wywołać jak instrukcję — kompilator nie zaprotestuje. Wynik po prostu ginie.
        // To odwrotność pułapki z odcinka 1: tam nawiasy były zbędne, tutaj brakuje odbiorcy wyniku.

        string message = provider();    // ✅ wynik trafia do zmiennej
        Console.WriteLine(message);

        // PUŁAPKA 2 — typ zmiennej musi zgadzać się z typem zwracanym
        // int number = provider();
        // CS0029: Cannot implicitly convert type 'string' to 'int'

        // PUŁAPKA 3 — metoda bez return nie pasuje do delegata
        GreetingProvider bad = PrintGreeting;
        // CS0407: 'void Pulapki.PrintGreeting()' has the wrong return type
        // PrintGreeting WYPISUJE tekst, ale go nie ZWRACA.
        // To dwie różne rzeczy — i tu widać, dlaczego typ zwracany jest częścią kontraktu, a nie szczegółem implementacji.
    }

    // ❌ Wypisuje, ale nie zwraca — zły typ zwracany.
    private static void PrintGreeting()
    {
        Console.WriteLine("Dzień dobry! Gotowy na nowy dzień?");
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
