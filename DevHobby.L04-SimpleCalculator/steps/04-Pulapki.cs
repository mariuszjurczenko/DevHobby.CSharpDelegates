using System;

namespace BeginnerDelegateCalculatorExample;

public delegate int MathOperation(int a, int b);

public class Pulapki
{
    public static void Main()
    {
        MathOperation operation = Add;
        int result = operation(5, 3);
        Console.WriteLine(result);

        // PUŁAPKA 1 — nazwy parametrów NIE chronią przed pomyloną kolejnością
        operation = SubtractWrong;
        result = operation(5, 3);
        // kompiluje się — oba parametry to int, kompilator nie protestuje ale wynik to -2, nie 2

        // PUŁAPKA 2 — liczba parametrów wciąż jest częścią sygnatury
        MathOperation bad = AddThree;
        // CS0123: No overload for 'AddThree' matches delegate 'MathOperation'
        // AddThree przyjmuje TRZY parametry, MathOperation deklaruje DWA.

        // PUŁAPKA 3 — typ zwracany nadal się liczy, nawet z dwoma parametrami
        MathOperation bad2 = PrintSum;
        // CS0407: 'void Pulapki.PrintSum(int, int)' has the wrong return type
        // PrintSum WYPISUJE sumę, ale jej nie ZWRACA.
    }

    private static int Add(int a, int b) => a + b;

    // Nazwy parametrów ZAMIENIONE względem znaczenia — kompiluje się,
    // ale liczy coś innego niż sugeruje nazwa metody.
    private static int SubtractWrong(int b, int a) => a - b;

    // Trzy parametry zamiast dwóch — zła liczba.
    private static int AddThree(int a, int b, int c) => a + b + c;

    // Zwraca void, nie int — zły typ zwracany.
    private static void PrintSum(int a, int b) => Console.WriteLine(a + b);
}
