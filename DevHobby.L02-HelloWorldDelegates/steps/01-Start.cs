// ODCINEK 2 — STAN 1: punkt startowy
// Jeszcze bez delegata — tylko dwie metody, obie z parametrem.
// obie mają ten sam kształt — przyjmują string, zwracają void.

using System;

public class Program
{
    public static void Main()
    {
        ShowHello("Jan");
        ShowGoodbye("Jan");
    }

    // Kształt: void (string)
    private static void ShowHello(string name)
    {
        Console.WriteLine($"Cześć, {name}!");
    }

    // Kształt: void (string) — identyczny
    private static void ShowGoodbye(string name)
    {
        Console.WriteLine($"Do widzenia, {name}!");
    }
}

// Main() wie, którą metodę wywołać. 
// Wiedza o wyborze i wiedza o wykonaniu siedzą w tym samym miejscu.
// Chcemy je rozdzielić, zaczynamy od włożenia metody do zmiennej.
