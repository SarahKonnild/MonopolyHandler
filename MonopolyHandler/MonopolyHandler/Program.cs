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
            game.GetPropertyCommand().LoadProperties();

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
                Console.WriteLine(players[i].name + " has token: " + players[i].token.tokenType + " and savings: " + players[i].holdings + " Monopoly Money");
            }
            Console.WriteLine("Is the above information correct? Please enter Y/N");
            var answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                Console.WriteLine("Welcome to Monopoly!");
                Console.WriteLine("This handler will idly await your input, to minimize the interference with the physical play");
                PlayerRound();
            }
            else {
                GameSetup();
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
            List<Player> otherPlayers = new List<Player>(players);
            otherPlayers.Remove(player);


            if (player.inPrison == false)
            {
                Console.WriteLine("You can do the following actions:");
                Console.WriteLine("Press 0 if you crossed start");
                Console.WriteLine("Press 1 if you went to jail");
                Console.WriteLine("Press 2 if you need a chance card");
                Console.WriteLine("Press 3 if you want to buy a property");
                Console.WriteLine("Press 4 if you want to trade a property with someone");
                Console.WriteLine("Press 5 if you are travelling somewhere");
                Console.WriteLine("Press 6 to transfer money to another player");

                var input = Console.ReadLine();

                //Switch case? Or If-statements? Choices choices. Polishing later.
                if (input == "0" || input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6")
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
                        PlayerRound();
                    }
                    else if (input == "2")
                    {
                        //give a random chance card
                    }
                    else if (input == "3")
                    {
                        List<Property> availableProperties = game.GetPropertyCommand().properties;
                        Console.WriteLine("Which property will you buy?");
                        for (int i = 0; i < availableProperties.Count; i++)
                        {
                            Console.WriteLine(i + ": " + availableProperties[i].name);
                        }
                        var answer = int.Parse(Console.ReadLine());
                        if (answer >= 0 || answer <= availableProperties.Count)
                        {
                            game.GetPlayerCommand().AddProperty(player, availableProperties[answer]);
                            game.GetPropertyCommand().SellProperty(availableProperties[answer]);
                            Console.WriteLine("Property was added!");
                            Console.WriteLine(player.name + " now holds the following properties: ");

                            for (int i = 0; i < player.properties.Count; i++)
                            {
                                Console.WriteLine(player.properties[i].name);
                            }
                            PlayerRound();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please try again...");
                            RoundHandler(player);
                        }
                    }
                    else if (input == "4")
                    {
                        if (otherPlayers.Count > 0)
                        {
                            Console.WriteLine("Who would you like to swap properties with?");
                            for (int i = 0; i < otherPlayers.Count; i++)
                            {
                                Console.WriteLine(i + ": " + otherPlayers[i].name);
                            }
                            var answer = int.Parse(Console.ReadLine());
                            if (answer >= 0 && answer <= otherPlayers.Count)
                            {
                                Player receiver = otherPlayers[answer];
                                if (receiver.properties.Count > 0)
                                {
                                    Property property1;
                                    Property property2;
                                    Console.WriteLine("Which property would " + player.name + " like to swap with?");
                                    for (int j = 0; j < player.properties.Count; j++)
                                    {
                                        Console.WriteLine(j + ": " + player.properties[j].name);
                                    }
                                    var prop1 = int.Parse(Console.ReadLine());
                                    if (prop1 >= 0 && prop1 <= player.properties.Count)
                                    {
                                        property1 = player.properties[prop1];

                                        Console.WriteLine("Which property would " + receiver.name + " like to swap with?");
                                        for (int k = 0; k < receiver.properties.Count; k++)
                                        {
                                            Console.WriteLine(k + ": " + receiver.properties[k].name);
                                        }
                                        var prop2 = int.Parse(Console.ReadLine());
                                        if (prop2 >= 0 && prop2 <= receiver.properties.Count)
                                        {
                                            property2 = receiver.properties[prop2]; //out of range exception

                                            Console.WriteLine("So " + player.name + " receives property " + property2.name);
                                            Console.WriteLine("and " + receiver.name + "receives property " + property1.name);
                                            Console.WriteLine("Is this correct? Please enter Y/N");
                                            var result = Console.ReadLine();
                                            if (result == "y" || result == "Y")
                                            {
                                                game.GetPlayerCommand().SwapProperties(player, receiver, property1, property2);
                                                Console.WriteLine("The swap is complete!");
                                                Console.WriteLine("Player " + player.name + " now has properties:");
                                                for (int l = 0; l < player.properties.Count; l++)
                                                {
                                                    Console.WriteLine(player.properties[l].name);
                                                }
                                                Console.WriteLine("Player " + receiver.name + " now has properties:");
                                                for (int l = 0; l < receiver.properties.Count; l++)
                                                {
                                                    Console.WriteLine(receiver.properties[l].name);
                                                }
                                                PlayerRound();
                                            }
                                            else
                                            {
                                                PlayerRound();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input, please try again.");
                                            PlayerRound();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input, please try again.");
                                        PlayerRound();
                                    }

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No other players to transfer to!");
                            PlayerRound();
                        }
                    }
                    else if (input == "5")
                    {
                        game.GetPlayerCommand().RemoveFunds(player, 50);
                        Console.WriteLine("You can now travel anywhere you please! Bon voyage!");
                        PlayerRound();
                    }
                    else if (input == "6")
                    {
                        if (otherPlayers.Count > 0)
                        {
                            Console.WriteLine("Who would you like to transfer money to?");
                            for (int i = 0; i < otherPlayers.Count; i++) { 
                                Console.WriteLine(i + ": " + otherPlayers[i].name);
                            }
                            var answer = int.Parse(Console.ReadLine());
                            if (answer >= 0 && answer <= otherPlayers.Count)
                            {
                                Console.WriteLine("How much would you like to transfer?");
                                var amount = int.Parse(Console.ReadLine());
                                if (amount > 0 && amount <= player.holdings)
                                {
                                    Player receiver = otherPlayers[answer];
                                    game.GetPlayerCommand().AddFunds(receiver, amount);
                                    game.GetPlayerCommand().RemoveFunds(player, amount);

                                    Console.WriteLine("Money was transferred!");
                                    Console.WriteLine("Player holdings are now:");
                                    Console.WriteLine(player.name + " with holdings: " + player.holdings);
                                    Console.WriteLine(receiver.name + " with holdings: " + receiver.holdings);
                                }
                                else
                                {
                                    //I wanna create more methods that can ensure that the process doesn't start all over again each time. 
                                    Console.WriteLine("Invalid amount, please try again.");
                                    PlayerRound();
                                }
                            }
                            else {
                                Console.WriteLine("That is not a player, please try again.");
                                PlayerRound();
                            }
                        }
                        else {
                            Console.WriteLine("No other players to transfer to!");
                            PlayerRound();
                        }

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
                    Console.WriteLine(player.name + "'s holdings are now: " + player.holdings);
                    PlayerRound();
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
                        PlayerRound();
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
