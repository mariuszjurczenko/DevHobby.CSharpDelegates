using System;

namespace BeginnerDelegateAgeGateExample;

public delegate bool AgeRule(int age);

public class Program
{
    public static void Main()
    {
        int[] goscie = { 15, 20, 40, 70 };

        Console.WriteLine("=== STREFA DLA DOROSŁYCH (18+) ===");
        AgeRule rule = IsAdult;
        CheckAccess(goscie, rule);

        Console.WriteLine("\n=== STREFA SENIORA (65+) ===");
        rule = IsSenior;
        CheckAccess(goscie, rule);

        Console.WriteLine("\n=== STREFA VIP (własna reguła “w locie”) ===");
        rule = wiek => wiek >= 21 && wiek <= 60;
        CheckAccess(goscie, rule);
    }

    private static bool IsSenior(int age) => age >= 65;

    private static bool IsAdult(int age) => age >= 18;

    private static void CheckAccess(int[] goscie, AgeRule rule)
    {
        foreach (int wiek in goscie)
        {
            bool wpuszczony = rule(wiek);
            string status = wpuszczony ? "✅ WPUSZCZONY" : "⛔ ODRZUCONY";
            Console.WriteLine($"Wiek {wiek}: {status}");
        }
    }
}
