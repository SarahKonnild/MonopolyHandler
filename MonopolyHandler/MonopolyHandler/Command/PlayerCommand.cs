﻿using MonopolyHandler.Objects;
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

        public List<Player> GetListOfPlayers()
        {
            return players;
        }
    }
}
