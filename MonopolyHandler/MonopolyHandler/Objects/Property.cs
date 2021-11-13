using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Objects
{
    class Property
    {
        public int id;
        public string name;
        public string color;
        public int price;
        public int rent;
        public int completeSetRent;

        public Property(int id, string name, string color, int price, int rent, int completeSetRent) {
            this.id = id;
            this.name = name;
            this.color = color;
            this.price = price;
            this.rent = rent;
            this.completeSetRent = completeSetRent;
        }
    }
}
