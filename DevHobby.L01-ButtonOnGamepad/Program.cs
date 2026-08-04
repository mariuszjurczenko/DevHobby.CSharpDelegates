using System;

public delegate void ButtonAction();

public class Program
{
    public static void Main()
    {
        ButtonAction actionOnX = Jump;

        Console.WriteLine("--- Tryb Eksploracji ---");
        Console.Write("Naciskasz [X]: ");
        actionOnX();

        actionOnX = Fire;

        Console.WriteLine("\n--- Tryb Walki ---");
        Console.Write("Naciskasz [X]: ");
        actionOnX();
    }

    private static void Jump()
    {
        Console.WriteLine("🦘 Postać podskakuje w górę!");
    }

    private static void Fire()
    {
        Console.WriteLine("💥 Postać oddaje strzał z pistoletu!");
    }
}
