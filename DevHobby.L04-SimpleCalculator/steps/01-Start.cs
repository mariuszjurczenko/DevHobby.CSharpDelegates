using System;

namespace BeginnerDelegateCalculatorExample;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== PROSTY KALKULATOR ===\n");

        int liczbaA = 5;
        int liczbaB = 3;

        Console.WriteLine($"{liczbaA} + {liczbaB} = {Calculate(liczbaA, liczbaB, "+")}");
        Console.WriteLine($"{liczbaA} - {liczbaB} = {Calculate(liczbaA, liczbaB, "-")}");
        Console.WriteLine($"{liczbaA} * {liczbaB} = {Calculate(liczbaA, liczbaB, "*")}");
    }

    // Zna WSZYSTKIE operacje na pamięć — dodanie nowej to edycja tej metody.
    private static int Calculate(int a, int b, string operacja)
    {
        switch (operacja)
        {
            case "+": return a + b;
            case "-": return a - b;
            case "*": return a * b;
            default: throw new ArgumentException("Nieznana operacja");
        }
    }
}

// Calculate musi znać wszystkie operacje z góry.
// Dodanie dzielenia = edycja switcha wewnątrz Calculate.
// Chcemy: Calculate (a raczej to, co go zastąpi) dostaje delegat z GOTOWĄ operacją,
// nie wie nic o tym, czym ta operacja jest wie tylko, że przyjmie dwie liczby i odda jedną.
