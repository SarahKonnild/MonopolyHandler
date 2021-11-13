using MonopolyHandler.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Objects
{
    class Game
    {
        private PlayerCommand playerCommand;
        private PropertyCommand propertyCommand;

        public Game(PlayerCommand playerCommand, PropertyCommand propertyCommand) {
            this.playerCommand = playerCommand;
            this.propertyCommand = propertyCommand;
        }

        public bool AddPlayer(string name, TokenType token) {
            bool result = playerCommand.CreatePlayer(name, (int) token);
            if (result)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
