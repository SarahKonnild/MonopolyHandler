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
        private List<Player> players;

        private Game(Banker banker, Jailer jailer, List<Player> players) {
            this.banker = banker;
            this.jailer = jailer;
            this.players = players;
        }

        public Game Initialize(List<Player> players) {
            return new Game(new Banker(), new Jailer(new List<Player>()), players);
        }
    }
}
