using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Objects
{
    class Player
    {
        public string name; 
        public Token token;
        public int holdings;
        public List<Property> properties;
        public bool inPrison;

        public Player(string name, Token token, int holdings, List<Property> properties, bool inPrison) {
            this.name = name;
            this.token = token;
            this.holdings = holdings;
            this.properties = properties;
            this.inPrison = inPrison;
        }
    }
}
