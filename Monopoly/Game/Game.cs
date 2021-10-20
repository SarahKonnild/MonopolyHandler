using Monopoly.Objects;
using Monopoly.Game.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Game
{
    public class Game
    {
        private Banker banker;
        private Jailer jailer;
        private Players players;

        private Game(Banker banker, Jailer jailer, Players players) {
            this.banker = banker;
            this.jailer = jailer;
            this.players = players;
        }

        public Game Initialize(List<Player> players) {

            //List<Property> properties =
            //read properties into the properties list
            //properties = Dataaccess.DataAccess.ReadProperties();
            //return new Game(players, properties);
            return null;
        }
    }
}
