// ODCINEK 1 — ZADANIE DOMOWE

using System;

public delegate void ButtonAction();

public class ZadanieDomowe
{
    public static void Main()
    {
        ButtonAction actionOnX = Jump;

        Console.WriteLine("--- Tryb Eksploracji ---");
        Console.Write("Naciskasz [X]: ");
        actionOnX();

        actionOnX = Fire;
        Console.WriteLine("\n--- Tryb Walki ---");
        Console.Write("Naciskasz [X]: ");
        actionOnX();

        // TODO 1: Podepnij Sneak pod actionOnX i wywołaj.
        //         Wypisz nagłówek "--- Tryb Skradania ---".

        // TODO 2 (eksperyment): napisz `actionOnX = Sneak();` z nawiasami.
        //         Jaki numer błędu zgłasza kompilator? Przeczytaj treść.

        // TODO 3 (eksperyment): zmień sygnaturę Sneak na `void Sneak(int speed)`.
        //         Jaki teraz jest błąd i czym różni się od poprzedniego?

        // TODO 4 (eksperyment): zmień typ zwracany Sneak na `bool`.
        //         Trzeci komunikat. Zapamiętaj wszystkie trzy.
    }

    private static void Jump() => Console.WriteLine("🦘 Postać podskakuje w górę!");

    private static void Fire() => Console.WriteLine("💥 Postać oddaje strzał z pistoletu!");

    // TODO 0: zaimplementuj metodę zgodną z ButtonAction.
    private static void Sneak() => throw new NotImplementedException();
}

/*
ROZWIĄZANIE (nie zaglądaj przed próbą):

    actionOnX = Sneak;
    Console.WriteLine("\n--- Tryb Skradania ---");
    Console.Write("Naciskasz [X]: ");
    actionOnX();

    private static void Sneak() => Console.WriteLine("🥷 Postać przykuca i skrada się.");

Odpowiedzi na eksperymenty:
  TODO 2 → CS0029: Cannot implicitly convert type 'void' to 'ButtonAction'
  TODO 3 → CS0123: No overload for 'Sneak' matches delegate 'ButtonAction'
  TODO 4 → CS0407: 'bool ZadanieDomowe.Sneak()' has the wrong return type

Wniosek: dopasowanie delegata to dopasowanie CAŁEJ sygnatury —
parametrów i typu zwracanego. Nazwa metody nie ma znaczenia.
*/
