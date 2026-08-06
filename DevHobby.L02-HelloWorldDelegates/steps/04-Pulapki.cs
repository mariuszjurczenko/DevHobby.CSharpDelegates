// ODCINEK 2 — STAN 4: trzy pułapki

using System;

public delegate void DisplayMessage(string text);

public class Pulapki
{
    public static void Main()
    {
        DisplayMessage myDelegate = ShowHello;

        // ─────────────────────────────────────────────────────────────
        // PUŁAPKA 1 — liczba argumentów przy wywołaniu
        // ─────────────────────────────────────────────────────────────
        myDelegate();                   // ❌ CS7036 - brak przekazanego argumentu

        myDelegate("Jan", "Kowalski");  // ❌ CS1593 - za dużo argumentów

        myDelegate("Jan");              // ✅ dokładnie jeden string


        // ─────────────────────────────────────────────────────────────
        // PUŁAPKA 2 — typ argumentu
        // ─────────────────────────────────────────────────────────────
        myDelegate(42);                 // ❌ CS1503: cannot convert from 'int' to 'string'


        // ─────────────────────────────────────────────────────────────
        // PUŁAPKA 3 — nazwa parametru NIE jest kontraktem
        // ─────────────────────────────────────────────────────────────
        // Wszystkie trzy poniższe pasują do DisplayMessage, mimo że parametry nazywają się zupełnie inaczej:

        myDelegate = ShowHello;    // parametr: name
        myDelegate("Anna");

        myDelegate = ShowHello2;   // parametr: wiadomosc
        myDelegate("Anna");

        myDelegate = ShowHello3;   // parametr: x
        myDelegate("Anna");

        // ⚡ ALE: argument nazwany bierze nazwę z DELEGATA, nie z metody. W czasie kompilacji nie wiadomo, która metoda tu wyląduje.
        myDelegate(text: "Anna");     // ✅ 'text' — z definicji delegata
        myDelegate(name: "Anna");     // ❌ CS1739 — 'name' pochodzi z metody
    }

    // ── Kandydaci pasujący ──────────────────────────────────────────
    private static void ShowHello(string name) => Console.WriteLine($"Cześć, {name}!");

    private static void ShowHello2(string wiadomosc) => Console.WriteLine($"Cześć, {wiadomosc}!");

    private static void ShowHello3(string x) => Console.WriteLine($"Cześć, {x}!");
}
