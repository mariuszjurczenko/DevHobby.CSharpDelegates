// ODCINEK 1 — STAN 2: definicja delegata + pierwsze przypisanie

using System;

// KROK 1: Definiujemy TYP delegata.
// To NIE jest metoda — nie ma ciała, nie ma klamerek.
// To definicja KSZTAŁTU: "metoda, która nic nie przyjmuje i nic nie zwraca".
// Stoi obok klasy, tak samo jak stałby enum albo interfejs.
public delegate void ButtonAction();

public class Program
{
    public static void Main()
    {
        // KROK 2: Przypisujemy metodę do zmiennej.
        //   Jump   -> daj mi SAMĄ METODĘ          ✅
        //   Jump() -> WYKONAJ metodę i daj wynik  ❌ (tu: void, nie da się przypisać)
        ButtonAction actionOnX = Jump;

        Console.WriteLine("--- Tryb Eksploracji ---");
        Console.Write("Naciskasz [X]: ");

        // KROK 3: Wywołujemy zmienną tak, jakby była metodą.
        actionOnX();
    }

    private static void Jump()
    {
        Console.WriteLine("🦘 Postać podskakuje w górę!");
    }

    private static void Fire()
    {
        Console.WriteLine("💥 Postać oddaje strzał z pistoletu!");
    }
}
