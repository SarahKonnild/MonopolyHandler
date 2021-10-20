using Monopoly.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Objects
{
    public class Property
    {
        public string name;
        public int price;
        public PropertyType type;
        public int baseRent;
        public int fullRent;

        public Property(string name, int price, PropertyType type, int baseRent, int fullRent) {
            this.name = name;
            this.price = price;
            this.type = type;
            this.baseRent = baseRent;
            this.fullRent = fullRent;
        }
    }

    //Add house

    //Add hotel
}
