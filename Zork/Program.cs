using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            Console.WriteLine(command);
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, ignoreCase: true, out Commands result) ? result : Commands.UNKNOWN; //THREE OPERATORS: If the first segment is true, it returns the statement before the : otherwise it returns the statement after the :.

    }
}


