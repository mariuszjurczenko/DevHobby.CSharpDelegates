using System;

namespace BeginnerDelegateAgeGateExample;

public class Program
{
    public static void Main()
    {
        int[] goscie = { 15, 20, 40, 70 };

        Console.WriteLine("=== STREFA DLA DOROSŁYCH (18+) ===");
        CheckAccess(goscie);
    }

    // Zna JEDNĄ regułę na pamięć — dodanie strefy seniora to kopiowanie tej metody.
    private static void CheckAccess(int[] goscie)
    {
        foreach (int wiek in goscie)
        {
            bool wpuszczony = wiek >= 18;
            string status = wpuszczony ? "✅ WPUSZCZONY" : "⛔ ODRZUCONY";
            Console.WriteLine($"Wiek {wiek}: {status}");
        }
    }
}

// CheckAccess musi znać regułę z góry — "18+" jest wpisane na sztywno w środku pętli.
// Dodanie strefy seniora (65+) obok tej samej strefy dla dorosłych = 
// albo kopiujesz całą metodę, albo dokładasz kolejny parametr i if/else wewnątrz.
// Chcemy: CheckAccess (a raczej to, co go zastąpi) dostaje delegat z GOTOWĄ regułą tak/nie, 
// nie wie nic o tym, CZYM ta reguła jest — wie tylko, że przyjmie wiek i odda decyzję bool.
