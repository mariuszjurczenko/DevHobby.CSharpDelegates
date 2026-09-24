using System;

namespace BeginnerDelegateParameterExample;

public class Orchestra
{
    public void Perform()
    {
        Console.WriteLine("Orkiestra gotowa, zaczynamy...");
        Console.WriteLine("Gramy improwizowanego jazza...");
        Console.WriteLine("Koniec utworu. Brawo!\n");
    }
}

public class Program
{
    public static void Main()
    {
        var orchestra = new Orchestra();
        orchestra.Perform();
    }
}

// Perform ma na sztywno wpisane WYWOŁANIE konkretnego utworu (jazz) w środku swojego ciała. 
// Żeby zagrać rocka zamiast jazzu, musisz wejść do środka
// Perform i zmienić tę jedną linijkę — albo skopiować całą metodę pod inną nazwą. 
// Orchestra miesza dwie role: "jak wygląda występ" (powitanie na wejściu, brawo na końcu) 
// i "co dokładnie gramy" (jazz). 
// Chcemy: Perform dostaje UTWÓR jako gotowy delegat z zewnątrz i sama nie wie nic o tym,
// CZYM ten utwór jest — wie tylko, że dostanie coś, 
// co da się wywołać bez parametrów i bez wyniku.
