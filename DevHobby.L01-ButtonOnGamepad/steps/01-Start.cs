// ODCINEK 1 — STAN 1: punkt startowy

using System;

// Nie ma tu jeszcze ani jednego delegata, tylko dwie zwykłe metody.
// Jump() i Fire() mają IDENTYCZNY kształt, nic nie przyjmują, nic nie zwracają.

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- Tryb Eksploracji ---");
        Console.Write("Naciskasz [X]: ");
        Jump();

        Console.WriteLine("\n--- Tryb Walki ---");
        Console.Write("Naciskasz [X]: ");
        Fire();
    }

    // Metoda #1 — brak parametrów, zwraca void
    private static void Jump()
    {
        Console.WriteLine("🦘 Postać podskakuje w górę!");
    }

    // Metoda #2 — brak parametrów, zwraca void
    private static void Fire()
    {
        Console.WriteLine("💥 Postać oddaje strzał z pistoletu!");
    }
}

// Kod wywołujący jest na sztywno przybity do konkretnych metod.
// Dodanie trybu skradania = edycja Main().
// Chcemy: JEDNA linijka wywołania, która robi różne rzeczy.
