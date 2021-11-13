using MonopolyHandler.Command;
using MonopolyHandler.Data_Access.Query;
using MonopolyHandler.Objects;
using System;

namespace MonopolyHandler
{
    class Program
    {
        private static Game game;
        static void Main(string[] args)
        {
            game = new Game(new PlayerCommand(), new PropertyCommand());

            Console.WriteLine("Welcome to the Monopoly Handler");
            Console.WriteLine("Press Enter to start a new game...");
            var key = Console.ReadKey();
            if (key.KeyChar == 13) { 
                
            }
        }
    }
}
