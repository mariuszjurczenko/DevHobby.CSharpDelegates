using System;

namespace BeginnerDelegateReturnValue;

// TODO 1: Zdefiniuj delegat MessageProvider — bez parametrów, zwracający string.

public class ZadanieDomowe
{
    public static void Main()
    {
        // TODO 2: Przypisz GetMorning do zmiennej delegata, wywołaj i ZAPISZ WYNIK do zmiennej string, potem wypisz.

        // TODO 3: Podmień na GetWork, wywołaj ponownie.

        // TODO 4: Podmień na GetEvening, wywołaj ponownie.

        // TODO 5 (eksperyment): jaka jest różnica między provider = GetMorning;  i  provider = GetMorning();
        //         Napisz oba i przeczytaj komunikat kompilatora dla drugiego.
    }

    // TODO 6: trzy metody bez parametrów, zwracające string przez `return`.
    private static string GetMorning() => throw new NotImplementedException();

    private static string GetWork() => throw new NotImplementedException();

    private static string GetEvening() => throw new NotImplementedException();
}

/*
ROZWIĄZANIE (nie zaglądaj przed próbą):

    public delegate string MessageProvider();

    MessageProvider provider = GetMorning;
    string message = provider();
    Console.WriteLine(message);

    provider = GetWork;
    message = provider();
    Console.WriteLine(message);

    provider = GetEvening;
    message = provider();
    Console.WriteLine(message);

    private static string GetMorning()
    {
        return "Dzień dobry! Gotowy na nowy dzień?";
    }

    private static string GetWork()
    {
        return "Czas na pracę — pierwszy task czeka.";
    }

    private static string GetEvening()
    {
        return "Dobry wieczór! Czas odpocząć od kodu.";
    }

Odpowiedź na TODO 5:
    provider = GetMorning;    ✅ przypisuje METODĘ do zmiennej delegata
    provider = GetMorning();  ❌ CS0029: Cannot implicitly convert type 'string' to 'MessageProvider'

    Zwróć uwagę, że komunikat jest INNY niż w odcinku 1. 
    Tam metoda zwracała `void`, więc kompilator mówił "cannot convert 'void'". 
    Tutaj metoda zwraca `string`, więc mówi "cannot convert 'string'". 
    Ta sama przyczyna, wykonałeś metodę i próbujesz przypisać jej WYNIK zamiast JEJ SAMEJ.
*/
