// ODCINEK 2 — STAN 2: Złota Zasada 3 Kroków, każdy krok podpisany

using System;

// KROK 1: DEFINIUJESZ — tworzysz szablon (typ), nie metodę
// Czytamy od prawej do lewej:
//   (string text)    → przyjmuje jeden tekst
//   void             → nic nie zwraca
//   DisplayMessage   → tak nazywa się mój nowy typ
//   delegate         → a to całe zdanie to definicja TYPU
//
// ⚠ KONTRAKTEM JEST TYP `string`, NIE NAZWA `text`.
//   Nazwa parametru w delegacie to dokumentacja dla człowieka
//   — kompilator jej nie porównuje z nazwą w metodzie.
public delegate void DisplayMessage(string text);

public class Program
{
    public static void Main()
    {
        // KROK 2: PRZYPISUJESZ — konkretna metoda ląduje w zmiennej
        // Bez nawiasów (patrz odcinek 1).
        // Kompilator sprawdza tu SYGNATURĘ:
        // liczba parametrów + typy parametrów + typ zwracany
        DisplayMessage myDelegate = ShowHello;

        // KROK 3: WYWOŁUJESZ — z nawiasami i z argumentem
        // "Jan" wchodzi do zmiennej, ta przekazuje go do ShowHello,
        // gdzie ląduje w parametrze `name`.
        myDelegate("Jan");          // → Cześć, Jan!

        // Podmiana metody. Linijka wywołania poniżej jest IDENTYCZNA.
        myDelegate = ShowGoodbye;
        myDelegate("Jan");          // → Do widzenia, Jan!
    }

    // Parametr nazywa się `name`, a w delegacie `text`. To jest OK.
    private static void ShowHello(string name)
    {
        Console.WriteLine($"Cześć, {name}!");
    }

    private static void ShowGoodbye(string name)
    {
        Console.WriteLine($"Do widzenia, {name}!");
    }
}
