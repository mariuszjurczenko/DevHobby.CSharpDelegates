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
}

public class Program
{
    public static void Main()
    {
        var orchestra = new Orchestra();
        orchestra.Perform(PlayJazz);
        orchestra.Perform(PlayRock);
        orchestra.Perform(() => Console.WriteLine("...gra Twoją własną melodię!"));
    }

    private static void PlayJazz() => Console.WriteLine("Gramy improwizowanego jazza...");

    private static void PlayRock() => Console.WriteLine("Gramy energetycznego rocka...");
}
