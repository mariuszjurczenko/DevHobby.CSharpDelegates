using System;

namespace BeginnerDelegateParameterExample;

public delegate void SongDelegate();

public class Orchestra
{
    public void Perform(SongDelegate song)
    {
        Console.WriteLine("Orkiestra gotowa, zaczynamy...");
        song();
        Console.WriteLine("Koniec utworu. Brawo!\n");
    }

    // PUŁAPKA 1 — sygnatura identyczna jak Perform, ale metoda ZAPOMINA
    //    wywołać song() w środku. Kompiluje się bez ostrzeżenia — parametr
    //    song jest poprawnym SongDelegate, po prostu nikt go nie woła.
    //    Kompilator milczy, bo to, czy wywołujesz parametr, jest kwestią
    //    LOGIKI ciała metody, a nie jej sygnatury.
    public void PerformSilently(SongDelegate song)
    {
        Console.WriteLine("Orkiestra gotowa, zaczynamy...");
        // song(); ← ta linijka zniknęła
        Console.WriteLine("Koniec utworu. Brawo!\n");
    }
}

public class Pulapki
{
    public static void Main()
    {
        var orchestra = new Orchestra();
        orchestra.Perform(PlayJazz);

        // PUŁAPKA 1 — parametr-delegat, którego nikt nie wywołuje w środku
        // orchestra.PerformSilently(PlayJazz);
        //   kompiluje się — song ma poprawny typ SongDelegate
        //   ale nic nie gra — napis „gotowa, zaczynamy” i „koniec utworu”
        //   wypisują się, a między nimi CISZA   


        // PUŁAPKA 2 — liczba parametrów wciąż jest częścią sygnatury
        // orchestra.Perform(PlaySongLoudly);
        //   CS1503: Argument 1: cannot convert from 'method group' to 'SongDelegate'
        //
        // PlaySongLoudly przyjmuje JEDEN parametr (int volume), SongDelegate
        // deklaruje ZERO. Ta sama zasada co w odcinkach 2, 4 i 5 — tylko że
        // tym razem konwersja metoda-grupa-na-delegat dzieje się w miejscu
        // ARGUMENTU wywołania, nie przy przypisaniu do zmiennej.
        // I dlatego zmienia się NUMER błędu: przy przypisaniu
        // (SongDelegate song = PlaySongLoudly;) kompilator mówi CS0123, a tutaj
        // najpierw przegrywa dopasowanie przeciążenia metody Perform, więc
        // zgłasza CS1503. Mechanizm jest ten sam — sprawdzanie sygnatury.
        // Zmierzone na .NET 10.0.401 (23.09.2026).


        // PUŁAPKA 3 — typ zwracany nadal się liczy
        // orchestra.Perform(TryPlayJazz);
        //   CS0407: 'bool Pulapki.TryPlayJazz()' has the wrong return type
        //
        // TryPlayJazz ZWRACA bool, SongDelegate deklaruje void. Dokładnie ta
        // sama różnica, którą widzieliśmy w odcinkach 3–5 (GetGreeting vs
        // PrintGreeting, Add vs PrintSum, IsAdult vs PrintIsAdult) — tylko
        // odwrócona: tam delegat OCZEKIWAŁ wartości, a metoda jej nie dawała;
        // tutaj delegat NIE oczekuje niczego, a metoda i tak coś zwraca.
        // Kompilator jest równie surowy w obie strony.
    }

    private static void PlayJazz() => Console.WriteLine("Gramy improwizowanego jazza...");

    // Jeden parametr zamiast zera — zła liczba.
    private static void PlaySongLoudly(int volume) => Console.WriteLine($"Gramy jazza na {volume}%...");

    // Zwraca bool, nie void — zły typ zwracany.
    private static bool TryPlayJazz()
    {
        Console.WriteLine("Gramy improwizowanego jazza...");
        return true;
    }
}
