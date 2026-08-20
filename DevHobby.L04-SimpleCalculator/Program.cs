using System;

namespace BeginnerDelegateCalculatorExample;

public delegate int MathOperation(int a, int b); 

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== PROSTY KALKULATOR ===\n");

        int liczbaA = 5;
        int liczbaB = 3;

        MathOperation operation = Add;
        int result = operation(liczbaA, liczbaB);
        Console.WriteLine($"{liczbaA} + {liczbaB} = {result}");

        operation = Multiply;
        result = operation(liczbaA, liczbaB);
        Console.WriteLine($"{liczbaA} * {liczbaB} = {result}");

        operation = Subtract;
        result = operation(liczbaA, liczbaB);
        Console.WriteLine($"{liczbaA} - {liczbaB} = {result}");

        operation = (a, b) => b == 0 ? 0 : a / b;
        result = operation(liczbaA, liczbaB);
        Console.WriteLine($"{liczbaA} / {liczbaB} = {result}");
    }

    private static int Subtract(int a, int b) => a - b;

    private static int Multiply(int a, int b) => a * b;

    private static int Add(int a, int b) => a + b;
}
