using System;

namespace BeginnerDelegateAgeGateExample;

// KROK 1: DEFINIUJESZ
// Ten delegat przechowuje funkcje, które przyjmują wiek (int) i zwracają decyzję tak/nie (bool).
public delegate bool AgeRule(int age);

public class Program
{
    public static void Main()
    {
        // KROK 2: PRZYPISUJESZ — bez nawiasów, jak zawsze
        AgeRule rule = IsAdult;

        // KROK 3: WYWOŁUJESZ — z nawiasem, JEDNYM argumentem, i ODBIERASZ WYNIK (dokładnie jak zwykły warunek)
        bool result = rule(20);

        if (result)
            Console.WriteLine("Wejście dozwolone");

        // Ta sama zmienna, inna metoda, ta sama linijka wywołania.
        rule = IsSenior;
        result = rule(20);

        if (result)
            Console.WriteLine("Wejście dozwolone");
        else
            Console.WriteLine("Wejście nie dozwolone");
            
        // I to samo wywołanie da się użyć DOKŁADNIE tak jak zwykły warunek if:
        if (rule(70))
        {
            Console.WriteLine("Wejście do strefy seniora dozwolone.");
        }
    }

    private static bool IsAdult(int age) => age >= 18;
    private static bool IsSenior(int age) => age >= 65;
}

// NOWOŚĆ W TYM ODCINKU:
// W odcinkach 1–4 delegat zwracał void, string albo int.
// Tutaj zwraca bool — i to zmienia sposób UŻYCIA wywołania: 
// rule(wiek) wstawia się DOKŁADNIE tam, gdzie zwykły warunek logiczny — w if,
// w &&, w ?:. To pierwszy przykład w serii, w którym delegat 
// pełni rolę "pytania", a nie "polecenia" ani "dostawcy danych".
