using MonopolyHandler.Command;
using MonopolyHandler.Data_Access.Query;
using MonopolyHandler.Objects;
using System;
using System.Collections.Generic;

namespace MonopolyHandler
{
    class Program
    {
        private static Game game;
        private static List<Player> players = new List<Player>();

        static void Main(string[] args)
        {
            game = new Game(new PlayerCommand(), new PropertyCommand());

            Console.WriteLine("Welcome to the Monopoly Handler");
            Console.WriteLine("Press Enter to start a new game...");
            var key = Console.ReadKey();
            if (key.KeyChar == 13) {
                GameSetup();
            }
        }

        //could probably just parse once when setting the var but oh well
        private static void GameSetup() {
            int amountOfPlayers = SetAmountOfPlayers();
            PlayerCreation(amountOfPlayers);

            players = game.GetPlayerCommand().GetListOfPlayers();

            Console.WriteLine("Here are the players:");
            for (int i = 0; i < players.Count; i++) {
                Console.WriteLine(players[i].name + " has token: " + players[i].token + " and savings: " + players[i].holdings + " Monopoly Money");
            }
            Console.WriteLine("Is the above information correct? Please enter Y/N");
            var answer = Console.ReadKey();
            if (answer.KeyChar != 89)
            {
                GameSetup();
            }
            else {
                Console.WriteLine("Welcome to Monopoly!");
                Console.WriteLine("This handler will idly await your input, to minimize the interference with the physical play");
            }
        }

        private static void PlayerRound() {
            Console.WriteLine("Which player rolled the die?");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + players[i].name);
            }

            var player = Console.ReadLine();
            if (int.Parse(player) > 0 && int.Parse(player) <= players.Count)
            {
                RoundHandler(players[int.Parse(player) - 1]);
            }
            else
            {
                Console.WriteLine("Invalid input, please try again...");
                PlayerRound();
            }
        }

        private static void RoundHandler(Player player) {
            if (player.inPrison == false)
            {
                Console.WriteLine("You can do the following actions:");
                Console.WriteLine("Press 0 if you crossed start");
                Console.WriteLine("Press 1 if you went to jail");
                Console.WriteLine("Press 2 if you need a chance card");
                Console.WriteLine("Press 3 if you want to buy a property");
                Console.WriteLine("Press 4 if you want to trade a property with someone");
                Console.WriteLine("Press 5 if you are travelling somewhere");

                var input = Console.ReadLine();

                //Switch case? Or If-statements? Choices choices. Polishing later.
                if (input == "0" || input == "1" || input == "2" || input == "3" || input == "4" || input == "5")
                {
                    if (input == "0")
                    {
                        game.GetPlayerCommand().AddFunds(player, 200);
                        Console.WriteLine("200 Monopoly Money was added to your wallet.");
                        Console.WriteLine(player.name + " now has: " + player.holdings);
                        PlayerRound();
                    }
                    else if (input == "1")
                    {
                        game.GetPlayerCommand().SendToPrison(player);
                        Console.WriteLine("Oh no! " + player.name + " is now in prison!");
                    }
                    else if (input == "2")
                    {
                        //give a random chance card
                    }
                    else if (input == "3")
                    {
                        List<Property> availableProperties = game.GetPropertyCommand().properties;
                        Console.WriteLine("Which property will you buy?");
                        for (int i = 0; availableProperties.Count < i; i++)
                        {
                            Console.WriteLine(i + ": " + availableProperties[i].name);
                            var answer = int.Parse(Console.ReadLine());
                            if (answer >= 0 || answer <= availableProperties.Count)
                            {
                                game.GetPlayerCommand().AddProperty(player, availableProperties[answer]);
                                Console.WriteLine("Property was added!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please try again...");
                                RoundHandler(player);
                            }

                        }
                    }
                    else if (input == "4")
                    {
                        //choose who to trade with
                        //Choose own property
                        //choose if trading money, property or both
                        //trade - create trade in PropertyCommands.
                    }
                    else if (input == "5") {
                        game.GetPlayerCommand().RemoveFunds(player, 50);
                        Console.WriteLine("You can now travel anywhere you please! Bon voyage!");
                    }
                }
            }
            else {
                PrisonHandling(player);
            }
        }

        private static void PrisonHandling(Player player) {
            Console.WriteLine("You're in prison!");
            Console.WriteLine("How will you get out?");
            Console.WriteLine("Press 0 to Pay 200");
            Console.WriteLine("Press 1 to Roll 2 matching numbers");
            var answer = Console.ReadLine();
            if (answer == "0" || answer == "1") {
                if (answer == "0")
                {
                    game.GetPlayerCommand().RemoveFunds(player, 200);
                    game.GetPlayerCommand().GetOutOfPrison(player);
                    Console.WriteLine("Congrats! You are out of prison now!");
                }
                else {
                    Console.WriteLine("Did you succeed? Please enter Y/N");
                    var success = Console.ReadKey();
                    if (success.KeyChar != 89)
                    {
                        Console.WriteLine("Better luck next time!");
                        PlayerRound();
                    }
                    else {
                        game.GetPlayerCommand().GetOutOfPrison(player);
                        Console.WriteLine("Congrats! You are out of prison now!");
                    }
                }
            }
        }

        //could also just take input of amount of players, and then loop it. I chose recursion.
        private static void PlayerCreation(int players) {
            for(int i = 0; i < players; i++) {
                Console.WriteLine("Enter the name of the player.");
                var name = Console.ReadLine();

                Console.WriteLine("Choose a player trait that best fits you...");
                Console.WriteLine("Press 0 for traveller");
                Console.WriteLine("Press 1 for big spender");
                Console.WriteLine("Press 2 for globetrotter");
                Console.WriteLine("Press 3 for money saver");
                var token = Console.ReadLine();

                if (token == "0" || token == "1" || token == "2" || token == "3")
                {
                    if (game.GetPlayerCommand().CreatePlayer(name, int.Parse(token)))
                    {
                        Console.WriteLine("Player " + name + " has been added.");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't add player, please try again...");
                        PlayerCreation(players);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid token input, please try again...");
                    PlayerCreation(players);
                }
            }
        }

        private static int SetAmountOfPlayers() {
            Console.WriteLine("How many players will play? Up to 4 players can play");
            var number = int.Parse(Console.ReadLine());
            if (number > 0 && number <= 4)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid amount of players. Please try again");
                SetAmountOfPlayers();
                return -1;
            }
        }
    }
}
