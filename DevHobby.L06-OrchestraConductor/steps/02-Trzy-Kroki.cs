using System;

namespace BeginnerDelegateParameterExample;

// KROK 1: DEFINIUJESZ
// Delegat reprezentuje "utwór do zagrania" — nie przyjmuje parametrów
// i niczego nie zwraca. Dokładnie ten sam kształt co ButtonAction
// z odcinka 1 (void ()) — nowość dopiero w kroku 2.
public delegate void SongDelegate();

// KROK 2: METODA PRZYJMUJE DELEGAT JAKO ZWYKŁY PARAMETR
// To jest sedno tego odcinka: parametr metody może mieć typ delegata,
// dokładnie tak samo jak typ int czy string.
public class Orchestra
{
    public void Perform(SongDelegate song)
    {
        Console.WriteLine("Orkiestra gotowa, zaczynamy...");
        song(); // Wywołujemy TO, co dostaliśmy z zewnątrz
    }
}

public class Program
{
    public static void Main()
    {
        var orchestra = new Orchestra();

        // KROK 3: PRZEKAZUJESZ — bez nawiasów, jak przy zwykłym przypisaniu, 
        // tylko że tym razem to ARGUMENT wywołania
        orchestra.Perform(PlayJazz);

        // Ta sama metoda Perform, INNY utwór podany jako argument.
        orchestra.Perform(PlayRock);
    }

    private static void PlayJazz() => Console.WriteLine("Gramy improwizowanego jazza...");
    private static void PlayRock() => Console.WriteLine("Gramy energetycznego rocka...");
}

// NOWOŚĆ W TYM ODCINKU:
// W odcinkach 1–5 delegat był ZMIENNĄ, którą definiowałeś, przypisywałeś i wywoływałeś 
// w tej samej metodzie Main(). 
// Tutaj pierwszy raz delegat PODRÓŻUJE jako argument do INNEJ metody (Perform) 
// — i to Perform, nie Main, decyduje, kiedy dokładnie go wywołać.
