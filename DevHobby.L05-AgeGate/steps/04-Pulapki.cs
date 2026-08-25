using System;

namespace BeginnerDelegateAgeGateExample;

public delegate bool AgeRule(int age);

public class Pulapki
{
    public static void Main()
    {
        AgeRule rule = IsAdult;
        bool wynik = rule(18);
        Console.WriteLine(wynik);

        // PUŁAPKA 1 — poprawna sygnatura nie znaczy poprawna reguła
        rule = IsAdultWrong;
        wynik = rule(18);
        //   ✅ kompiluje się — sygnatura pasuje co do joty: int -> bool
        //   ❌ ale dla wieku 18 zwraca false, nie true
        //
        // IsAdultWrong używa `>` zamiast `>=`. Kompilator sprawdza WYŁĄCZNIE typy w sygnaturze 
        // nie ma pojęcia, że próg wieku pełnoletności to "18 i więcej", nie "więcej niż 18". 
        // To trzecia odsłona tej samej rodziny błędów: 
        // w odcinku 3 znikał WYNIK, w odcinku 4 ZAMIENIAŁY SIĘ parametry, tutaj myli się GRANICĘ warunku 
        // i za każdym razem kompilator milczy, bo widzi tylko sygnaturę, nigdy logikę.

        // PUŁAPKA 2 — liczba parametrów wciąż jest częścią sygnatury
        AgeRule bad = HasAccessLevel;
        // CS0123: No overload for 'HasAccessLevel' matches delegate 'AgeRule'   
        // HasAccessLevel przyjmuje DWA parametry, AgeRule deklaruje JEDEN.
        // Ta sama zasada co w odcinku 2 (tam różnica była zero kontra jeden)
        // i w odcinku 4 (tam dwa kontra trzy) 
        // liczba parametrów zawsze musi zgadzać się co do jednego.

        // PUŁAPKA 3 — typ zwracany nadal się liczy
        AgeRule bad2 = PrintIsAdult;
        // CS0407: 'void Pulapki.PrintIsAdult(int)' has the wrong return type
        // PrintIsAdult WYPISUJE decyzję, ale jej nie ZWRACA 
        // dokładnie ta sama różnica, którą widzieliśmy w odcinku 3 (GetGreeting vs PrintGreeting).
        // Delegat zwracający bool nie akceptuje metody zwracającej void, nawet jeśli "w praktyce robi to samo.
    }

    private static bool IsAdult(int age) => age >= 18;

    // ❌ Zły próg — `>` zamiast `>=`. Sygnatura identyczna, wynik inny dokładnie na granicy (age == 18).
    private static bool IsAdultWrong(int age) => age > 18;

    // ❌ Dwa parametry zamiast jednego — zła liczba.
    private static bool HasAccessLevel(int age, int minLevel) => age >= minLevel;

    // ❌ Zwraca void, nie bool — zły typ zwracany.
    private static void PrintIsAdult(int age) => Console.WriteLine(age >= 18);
}
