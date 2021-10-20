using Monopoly.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Game.Handlers
{
    public class Banker
    {
        public List<Property> properties;


        public Banker() {
        
        }

        public void PassedStart(Player player) {
            player.AddFunds(200);
        }

        public bool BoughtProperty(Property property, Player player) {
            if (properties.Contains(property))
            {
                player.AddProperty(property);
                player.RemoveFunds(property.price);
                properties.Remove(property);
                return true;
            }
            else {
                return false;
            }
            
        }

        public bool SoldProperty(Property property, Player player) {
            if (player.properties.Contains(property)){
                player.RemoveProperty(property);
                player.AddFunds(property.price);
                properties.Add(property);
                return true;
            }
            else {
                return false;
            }

        }

        public bool TradeProperty(Property property1, int money1, Player giver, int money2, Player receiver)
        {
            if (giver.properties.Contains(property1))
            {
                giver.properties.Remove(property1);
                receiver.properties.Add(property1);

                if (money1 != 0)
                {
                    receiver.AddFunds(money1);
                    giver.RemoveFunds(money1);
                }
                if (money2 != 0)
                {
                    giver.AddFunds(money2);
                    receiver.RemoveFunds(money2);
                }

                return true;
            }
            else {
                return false;
            }
        }

        public bool TradeProperty(Property property1, int money1, Player giver, Property property2, int money2, Player receiver) {
            if (giver.properties.Contains(property1) && receiver.properties.Contains(property2))
            {
                giver.properties.Remove(property1);
                receiver.properties.Add(property1);
                receiver.properties.Remove(property2);
                giver.properties.Add(property2);

                if (money1 != 0)
                {
                    giver.RemoveFunds(money1);
                    receiver.AddFunds(money1);
                }
                if (money2 != 0)
                {
                    receiver.RemoveFunds(money2);
                    giver.AddFunds(money2);
                }

                return true;
            }
            else {
                return false;
            }
        }



    }
}
