using System;

namespace BeginnerDelegateParameterExample;

// TODO 1: Delegat SongDelegate już znasz z Program.cs — użyj go bez zmian.
public delegate void SongDelegate();

public class Orchestra
{
    // TODO 2: Dopisz metodę PerformWithSupport(SongDelegate support, SongDelegate mainAct),
    //         która PRZYJMUJE DWA delegaty jako parametry:
    //         - najpierw wypisuje "Support gra pierwszy...", potem wywołuje support()
    //         - następnie wypisuje "Gwiazda wieczoru wchodzi na scenę...", potem wywołuje mainAct()
}

public class ZadanieDomowe
{
    public static void Main()
    {
        var orchestra = new Orchestra();

        // TODO 3: Wywołaj PerformWithSupport, przekazując PlayAcoustic jako support
        //         i PlayJazz jako mainAct.

        // TODO 4 (eksperyment): przekaż jako support lambdę „w locie", a jako
        //         mainAct — PlayRock. Zamień w głowie kolejność argumentów —
        //         obserwuj, w jakiej kolejności faktycznie grają.
    }

    private static void PlayAcoustic() => Console.WriteLine("Gramy akustyczny support...");
    private static void PlayJazz() => Console.WriteLine("Gramy improwizowanego jazza...");
    private static void PlayRock() => Console.WriteLine("Gramy energetycznego rocka...");
}

/*
ROZWIĄZANIE (nie zaglądaj przed próbą):

    public class Orchestra
    {
        public void PerformWithSupport(SongDelegate support, SongDelegate mainAct)
        {
            Console.WriteLine("🎤 Support gra pierwszy...");
            support();
            Console.WriteLine("🎻 Gwiazda wieczoru wchodzi na scenę...");
            mainAct();
        }
    }

    var orchestra = new Orchestra();
    orchestra.PerformWithSupport(PlayAcoustic, PlayJazz);
    orchestra.PerformWithSupport(() => Console.WriteLine("🎵 ...support gra coś swojego!"), PlayRock);

Odpowiedź na TODO 4:
    Kolejność wywołania NIE zależy od tego, w jakiej kolejności napisałeś
    metody PlayAcoustic/PlayJazz/PlayRock w pliku, ani od tego, który
    argument "wygląda" na pierwszy w Twojej głowie — zależy WYŁĄCZNIE
    od kolejności PARAMETRÓW w definicji PerformWithSupport(support, mainAct)
    i od tego, w jakiej kolejności ciało metody je WYWOŁUJE. Podanie lambdy
    jako support i PlayRock jako mainAct wciąż zagra support PIERWSZY —
    bo to support() stoi wyżej w ciele metody, niezależnie od tego, 
    CZYM jest przekazany delegat (nazwana metoda czy lambda).
*/
