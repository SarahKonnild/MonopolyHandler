using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Objects
{
    class Property
    {
        public string name;
        public string color;
        public int price;
        public int rent;
        public int completeSetRent;

        public Property(string name, string color, int price, int rent, int completeSetRent) {
            this.name = name;
            this.color = color;
            this.price = price;
            this.rent = rent;
            this.completeSetRent = completeSetRent;
        }
    }
}
