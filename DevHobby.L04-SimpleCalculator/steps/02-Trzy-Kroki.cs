using System;

namespace BeginnerDelegateCalculatorExample;

// KROK 1: DEFINIUJESZ
// Ten delegat przechowuje funkcje, które przyjmują DWIE liczby całkowite i zwracają jedną liczbę całkowitą.
public delegate int MathOperation(int a, int b);

public class Program
{
    public static void Main()
    {
        // KROK 2: PRZYPISUJESZ — bez nawiasów, jak zawsze
        MathOperation operation = Add;

        // KROK 3: WYWOŁUJESZ — z nawiasami, DWOMA argumentami, i ODBIERASZ WYNIK
        int result = operation(5, 3); // 8
        Console.WriteLine(result);

        // Ta sama zmienna, inna metoda, ta sama linijka wywołania.
        operation = Multiply;
        result = operation(5, 3); // 15
        Console.WriteLine(result);

        // Ta sama zmienna, inna metoda, ta sama linijka wywołania.
        operation = Subtract;
        result = operation(5, 3);
        Console.WriteLine(result);
    }

    private static int Add(int a, int b) => a + b;
    private static int Subtract(int a, int b) => a - b;
    private static int Multiply(int a, int b) => a * b;
}

// NOWOŚĆ W TYM ODCINKU:
// W odcinkach 1–3 delegat przyjmował ZERO albo JEDEN parametr.
// Tutaj przyjmuje DWA — i jednocześnie ZWRACA wynik, tak jak w odcinku 3.
// To pierwszy przykład w serii, który łączy WEJŚCIE i WYJŚCIE naraz.
