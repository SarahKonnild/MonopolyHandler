using Monopoly.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Objects
{
    public class Player
    {
        public string name;
        public int money;
        public List<Property> properties;
        //public Token token;
        public int score;

        public Player(string name, int money, int score, List<Property> properties//, Token token
            ) {
            this.name = name;
            this.money = money;
            this.score = score;
            this.properties = properties;
            //this.token = token;
        }
    }

    public class Token
    {
        public TokenType type;
        public PlayerTrait trait;

        public Token(TokenType type, PlayerTrait trait) {
            this.type = type;
            this.trait = trait;
        }
    }

    public class PlayerTrait {
        public string description;
        public TokenType tokenType;

        public PlayerTrait(string description, TokenType tokenType) {
            this.description = description;
            this.tokenType = tokenType;
        }
    }

}
