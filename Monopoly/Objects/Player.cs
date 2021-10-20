using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Objects
{
    public class Player
    {
        public string name;
        public int money;
        //public List<Properties> properties;
        //public Token token;
        public int score;

        public Player(string name, int money, int score //, List<Properties> properties, Token token
            ) {
            this.name = name;
            this.money = money;
            this.score = score;
            //this.properties = properties;
            //this.token = token;
        }
    }


}
