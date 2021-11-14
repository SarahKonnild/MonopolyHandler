using MonopolyHandler.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Command
{
    class PlayerCommand
    {
        public List<Player> players;
        public PlayerCommand() {
            players = new List<Player>();
        }

        public bool CreatePlayer(string name, int token) {
            if (players.Count != 0)
            {
                if (players.Exists(x => x.token.tokenType == (TokenType)token))
                {
                    return false;
                }
                else
                {
                    Player player = new Player(name, new Token((TokenType)token, (BonusTypes)token), 1500, new List<Property>(), false);
                    players.Add(player);
                    return true;
                }
            }
            else {
                Player player = new Player(name, new Token((TokenType)token, (BonusTypes)token), 1500, new List<Property>(), false);
                players.Add(player);
                return true;
            }

        }

        public void AddFunds(Player player, int sum) {
            player.holdings += sum;
        }

        public void RemoveFunds(Player player, int sum) {
            player.holdings -= sum;
        }

        public void AddProperty(Player player, Property property) {
            player.properties.Add(property);
        }

        public void RemoveProperty(Player player, Property property) {
            player.properties.Remove(property);
        }

        public void SendToPrison(Player player) {
            player.inPrison = true;
        }

        public void GetOutOfPrison(Player player) {
            player.inPrison = false;
        }

        public void TransferMoneyToAnotherPlayer(Player player1, Player player2, int amount) {
            RemoveFunds(player1, amount);
            AddFunds(player2, amount);
        }

        public void GivePlayerProperty(Player player1, Player player2, Property property) {
            RemoveProperty(player1, property);
            AddProperty(player2, property);
        }

        public void BuyAnotherPlayerProperty(Player player1, Player player2, Property property, int sum) {
            RemoveProperty(player1, property);
            AddProperty(player2, property);

            AddFunds(player1, sum);
        }

        public void SwapProperties(Player player1, Player player2, Property property1, Property property2)
        {
            RemoveProperty(player1, property1);
            RemoveProperty(player2, property2);

            AddProperty(player1, property1);
            AddProperty(player2, property2);
        }

        public List<Player> GetListOfPlayers()
        {
            return players;
        }
    }
}
