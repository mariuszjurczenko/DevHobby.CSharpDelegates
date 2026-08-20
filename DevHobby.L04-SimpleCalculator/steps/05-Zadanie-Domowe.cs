using System;
using System.Collections.Generic;

namespace BeginnerDelegateCalculatorExample;

// TODO 1: Zdefiniuj delegat BinaryOperation — dwa parametry decimal, zwraca decimal.

public class ZadanieDomowe
{
    public static void Main()
    {
        decimal liczbaA = 10m;
        decimal liczbaB = 4m;

        // TODO 2: Zbuduj Dictionary<string, BinaryOperation> mapujący "+", "-", "*"
        //         na metody Add / Subtract / Multiply.
        //         Warunek zaliczenia: sam wybór operacji nie może użyć if/switch —
        //         instrukcja może wybrać delegat, ale nie liczyć wyniku.

        // TODO 3: Dla operatora "+" pobierz delegat ze słownika i wywołaj go
        //         dla liczbaA i liczbaB. Wypisz wynik.

        // TODO 4: To samo dla "-" i "*".

        // TODO 5 (warunek zaliczenia): sprawdź operator, którego NIE MA w słowniku
        //         (np. "%"). Program nie może wywołać null — użyj TryGetValue
        //         i wypisz czytelny komunikat zamiast wyjątku.

        // TODO 6 (eksperyment): dodaj CZWARTĄ operację (np. Divide) bez zmiany
        //         niczego poza jedną metodą i jednym wpisem w słowniku.
        //         Ile linijek istniejącego kodu musiałeś dotknąć?
    }

    // TODO 7: zaimplementuj — zwraca a + b
    private static decimal Add(decimal a, decimal b) => throw new NotImplementedException();

    // TODO 8: zaimplementuj — zwraca a - b
    private static decimal Subtract(decimal a, decimal b) => throw new NotImplementedException();

    // TODO 9: zaimplementuj — zwraca a * b
    private static decimal Multiply(decimal a, decimal b) => throw new NotImplementedException();
}

/*
ROZWIĄZANIE (nie zaglądaj przed próbą):

    public delegate decimal BinaryOperation(decimal a, decimal b);

    var operations = new Dictionary<string, BinaryOperation>
    {
        ["+"] = Add,
        ["-"] = Subtract,
        ["*"] = Multiply,
    };

    decimal liczbaA = 10m;
    decimal liczbaB = 4m;

    foreach (var op in new[] { "+", "-", "*", "%" })
    {
        if (operations.TryGetValue(op, out BinaryOperation? operation))
        {
            Console.WriteLine($"{liczbaA} {op} {liczbaB} = {operation(liczbaA, liczbaB)}");
        }
        else
        {
            Console.WriteLine($"Nieznana operacja: {op}");
        }
    }

    private static decimal Add(decimal a, decimal b) => a + b;
    private static decimal Subtract(decimal a, decimal b) => a - b;
    private static decimal Multiply(decimal a, decimal b) => a * b;

Output:
    10 + 4 = 14
    10 - 4 = 6
    10 * 4 = 40
    Nieznana operacja: %

Wniosek: `Dictionary<string, BinaryOperation>` to nic innego niż tabela decyzyjna,
w której kluczem jest tekst, a wartością — delegat. Dodanie operacji "/" to jeden
nowy wpis w słowniku i jedna nowa metoda. Zero dotykania istniejącego kodu wyboru.
To jest dokładnie ten sam mechanizm, na którym stoi router komend w odcinku 21.
*/
