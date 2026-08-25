using System;

namespace BeginnerDelegateAgeGateExample;

// TODO 1: Zdefiniuj delegat AccessRule — dwa parametry (int age, bool hasPermission), zwraca bool.

public class ZadanieDomowe
{
    public static void Main()
    {
        // TODO 2: Zbuduj zmienną AccessRule i podepnij pod nią AllowAdults.
        //         Wywołaj ją dla minimum trzech zestawów danych (age, hasPermission) i wypisz wynik dla każdego.

        // TODO 3: Pod TĘ SAMĄ zmienną podepnij AllowWithPermission i powtórz wywołanie dla tych samych zestawów danych.
        //         Wynik ma się różnić tam, gdzie hasPermission == false, a age < 18.
    }

    // TODO 4: zaimplementuj — true, jeśli age >= 18 (permission bez znaczenia)
    private static bool AllowAdults(int age, bool hasPermission) => throw new NotImplementedException();

    // TODO 5: zaimplementuj — true, jeśli age >= 18 LUB hasPermission == true
    private static bool AllowWithPermission(int age, bool hasPermission) => throw new NotImplementedException();
}

/*
ROZWIĄZANIE (nie zaglądaj przed próbą):

    public delegate bool AccessRule(int age, bool hasPermission);

    var zestawy = new (int Age, bool HasPermission)[]
    {
        (15, false),
        (15, true),
        (20, false),
    };

    AccessRule rule = AllowAdults;
    foreach (var z in zestawy)
        Console.WriteLine($"AllowAdults({z.Age}, {z.HasPermission}) = {rule(z.Age, z.HasPermission)}");

    rule = AllowWithPermission;
    foreach (var z in zestawy)
        Console.WriteLine($"AllowWithPermission({z.Age}, {z.HasPermission}) = {rule(z.Age, z.HasPermission)}");

    private static bool AllowAdults(int age, bool hasPermission) => age >= 18;
    private static bool AllowWithPermission(int age, bool hasPermission) => age >= 18 || hasPermission;

Output:
    AllowAdults(15, False) = False
    AllowAdults(15, True) = False
    AllowAdults(20, False) = True
    AllowWithPermission(15, False) = False
    AllowWithPermission(15, True) = True
    AllowWithPermission(20, False) = True

Wniosek: Dwa delegaty tej samej sygnatury (int, bool) -> bool mogą reprezentować zupełnie inne reguły biznesowe. 
         Wywołujący (pętla foreach) nie wie i nie musi wiedzieć, którą regułę woła.
         To dokładnie ten sam mechanizm co Strategy Pattern w odcinku 19, tylko bez jeszcze jednej warstwy interfejsu.
*/
