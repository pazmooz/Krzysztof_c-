using System;
using System.Collections.Generic;

internal class Program
{
    static bool runs = true;

    public delegate void ExitProgramDelegate();

    static ExitProgramDelegate exitDel = () =>
    {
        runs = false;
    };

    static void OnResult(string result)
    {
        Console.WriteLine(result);
    }

    static string ReadArgument()
    {
        return Console.ReadLine();
    }

    private static void Main(string[] args)
    {
        bool runs = true;

        var commands = new Dictionary<string, Operation>();
        commands.Add("sum", new Sum());
        commands.Add("exit", new Exit());

        while (runs)
        {
            string? command = Console.ReadLine();

            if (commands.ContainsKey(command))
            {
                commands[command].Perform();
            }
            else if (command == "exit")
            {
                ExitDel();
            }
            else if (command == "dif")
            {
                int firstTerm = int.Parse(Console.ReadLine());
                int secondTerm = int.Parse(Console.ReadLine());

                Console.WriteLine(firstTerm - secondTerm);
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }
    }

    internal static void ExitDel()
    {
        throw new NotImplementedException();
    }
}

class Operation
{
    public virtual void Perform() { }
}

class Sum : Operation
{
    public override void Perform()
    {
        int firstTerm = int.Parse(Console.ReadLine());
        int secondTerm = int.Parse(Console.ReadLine());
        Console.WriteLine(firstTerm + secondTerm);
    }
}

class Exit : Operation
{
    public override void Perform()
    {
        Console.WriteLine("Exiting program...");
        Program.ExitDel();
    }
}
