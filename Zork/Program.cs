using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Zork!");
            SpawnPlayer("West of House");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Rooms[Location.Row, Location.Column]);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:
                        outputString = $"You moved {command}.";
                        Location.Row++;
                        break;

                    case Commands.SOUTH:
                        outputString = $"You moved {command}.";
                        Location.Row--;
                        break;

                    case Commands.EAST:
                        outputString = $"You moved {command}.";
                        Location.Column++;
                        break;

                    case Commands.WEST:
                        outputString = $"You moved {command}.";
                        Location.Column--;
                        break;

                    default:
                        outputString = "Uknown Command.";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, ignoreCase: true, out Commands result) ? result : Commands.UNKNOWN; //THREE OPERATORS: If the first segment is true, it returns the statement before the : otherwise it returns the statement after the :.

        //private static readonly List<Commands> Directions = new List<Commands>()
        //{
        //    Commands.NORTH,
        //    Commands.SOUTH,
        //    Commands.EAST,
        //    Commands.WEST,
        //};


        private static readonly string[,] Rooms =
        {
            {"Rocky Trail", "South of House", "Canyon View" },
            {"Forest", "West of House", "Behind House" },
            {"Dense Woods", "Noth of House", "Clearing" }
        };

        private static (int Row, int Column) Location;
        private static void SpawnPlayer(string roomName)
        {

            Location = IndexOf(Rooms, roomName);
            if ((Location.Row, Location.Column) == (-1, -1))
            {
                throw new Exception($"Did not find room: {roomName}");
            }

        }

        private static (int Row, int Column) IndexOf(string[,] values, string valueToFind)
        {
            for (int row = 0; row < Rooms.GetLength(0); row++)
            {
                for (int column = 0; column < Rooms.GetLength(1); column++)
                {
                    if (valueToFind == values[row, column])
                    {
                        
                        return (row, column);
                    }

                }

            }

            return (-1, -1);
        }
    }

}

//Method to print each element of an array
/*foreach (string room in Rooms)
{
    console.WriteLine(room);
}*/
