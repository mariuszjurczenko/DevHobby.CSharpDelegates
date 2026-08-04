// ODCINEK 1 — STAN 4: trzy pułapki

using System;

public delegate void ButtonAction();

public class Pulapki
{
    public static void Main()
    {
        // ─────────────────────────────────────────────────────────────
        // PUŁAPKA 1 — nawiasy przy przypisaniu
        // ─────────────────────────────────────────────────────────────
        ButtonAction bad1 = Jump();
        
        // CS0029: Cannot implicitly convert type 'void' to 'ButtonAction'
        // Kompilator wykonał Jump(), dostał void (czyli NIC) i próbuje to NIC przypisać do zmiennej typu ButtonAction.
        // ⚠ Uwaga na przyszłość: jeśli metoda ZWRACA delegat, to `= GetAction()` jest poprawne. 
        // Nawiasy same w sobie nie są błędem — błędem jest niedopasowanie typu wyniku.

        ButtonAction ok = Jump;
        ok();


        // ─────────────────────────────────────────────────────────────
        // PUŁAPKA 2 — niezainicjalizowany delegat to null
        // ─────────────────────────────────────────────────────────────
        // Delegat jest TYPEM REFERENCYJNYM. Nie ma wartości domyślnej takiej jak 0 dla int. Pusta zmienna = null.

        ButtonAction? actionOnY = null;

        actionOnY();             // 💥 NullReferenceException — RUNTIME, nie kompilacja

        actionOnY?.Invoke();     // ✅ bezpiecznie: sprawdza null, potem wywołuje
        Console.WriteLine("Przeżyliśmy wywołanie pustego delegata.");

        actionOnX(); // to lukier składniowy na actionOnX.Invoke().
        // Poniższe dwie linie są równoważne:
        ok.Invoke();
        ok();


        // ─────────────────────────────────────────────────────────────
        // PUŁAPKA 3 — liczy się SYGNATURA, nie nazwa
        // ─────────────────────────────────────────────────────────────
        ButtonAction bad3 = Crouch;
        
        // CS0123: No overload for 'Crouch' matches delegate 'ButtonAction'
        // Crouch przyjmuje int. ButtonAction mówi: żadnych parametrów.
        // Kontrakt sprawdzany NA ETAPIE KOMPILACJI — to przewaga delegatów nad refleksją i dynamic.

        ButtonAction bad4 = IsGrounded;
        // Ten sam błąd z innego powodu: IsGrounded zwraca bool, a ButtonAction deklaruje void.
    }

    private static void Jump() => Console.WriteLine("🦘 Postać podskakuje w górę!");

    private static void Fire() => Console.WriteLine("💥 Postać oddaje strzał z pistoletu!");

    // Świetna nazwa dla akcji na padzie — ale ZŁY KSZTAŁT.
    private static void Crouch(int height) => Console.WriteLine($"Kucanie na wysokość {height}.");

    // Nic nie przyjmuje, ale ZWRACA bool — też nie pasuje.
    private static bool IsGrounded() => true;
}
