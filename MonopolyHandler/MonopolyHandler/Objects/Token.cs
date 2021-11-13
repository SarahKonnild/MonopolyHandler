using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Objects
{
    class Token
    {
        public TokenType tokenType;
        public BonusTypes bonusType;

        public Token(TokenType tokenType, BonusTypes bonusType) {
            this.tokenType = tokenType;
            this.bonusType = bonusType;
        }
    }

    enum BonusTypes { 
        Travel,
        Spender,
        Globetrotter,
        Saver
    }

    enum TokenType {
       Airplane,
       Dog,
       Car,
       Vault
    }
}
