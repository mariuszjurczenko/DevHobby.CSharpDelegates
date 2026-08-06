// ODCINEK 2 — ZADANIE DOMOWE

using System;

// TODO 1: Zdefiniuj delegat ShowPrice przyjmujący decimal i zwracający void.

public class ZadanieDomowe
{
    public static void Main()
    {
        decimal amount = 100m;

        // TODO 2: Przypisz ShowNetPrice do zmiennej delegata i wywołaj dla `amount`.

        // TODO 3: Podmień na ShowGrossPrice i wywołaj dla tej samej kwoty.

        // TODO 4 (eksperyment): spróbuj przypisać ShowPriceWithCurrency.
        // Jaki numer błędu? Przeczytaj treść komunikatu i wyjaśnij sobie, KTÓRA część sygnatury się nie zgadza.
    }

    // TODO: zaimplementuj — wypisuje kwotę netto
    private static void ShowNetPrice(decimal amount) => throw new NotImplementedException();

    // TODO: zaimplementuj — dolicza 23% VAT i wypisuje kwotę brutto
    private static void ShowGrossPrice(decimal amount) => throw new NotImplementedException();

    // Kandydat do eksperymentu z TODO 4 — celowo NIE pasuje.
    private static void ShowPriceWithCurrency(decimal amount, string currency) => Console.WriteLine($"{amount:F2} {currency}");
}

/*
ROZWIĄZANIE (nie zaglądaj przed próbą):

    public delegate void ShowPrice(decimal amount);

    ShowPrice show = ShowNetPrice;
    show(amount);

    show = ShowGrossPrice;
    show(amount);

    private static void ShowNetPrice(decimal amount) => Console.WriteLine($"Netto: {amount:F2} zł");

    private static void ShowGrossPrice(decimal amount) => Console.WriteLine($"Brutto: {amount * 1.23m:F2} zł");

Output:
    Netto: 100,00 zł
    Brutto: 123,00 zł

Odpowiedzi na eksperymenty:
  TODO 4 → CS0123: No overload for 'ShowPriceWithCurrency' matches delegate 'ShowPrice'
           Nie zgadza się LICZBA parametrów — delegat deklaruje jeden, metoda ma dwa.
           Typy pierwszego parametru i typ zwracany są zgodne, ale to nie wystarcza:
           sygnatura musi pasować w całości.

Wniosek: sygnatura = liczba parametrów + typy parametrów + typ zwracany.
Nazwa metody nie liczy się wcale, nazwa parametru liczy się tylko przy
argumentach nazwanych.
*/
